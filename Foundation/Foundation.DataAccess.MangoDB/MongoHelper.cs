using MongoDB.Driver;
using System;
using Foundation.Domain.Entity;

namespace Foundation.DataAccess.MongoDB
{
    static public class MongoHelper
    {
        static public string GetCollectionName<TEntity>() => GetCollectionName(typeof(TEntity));


        static public string GetCollectionName(Type typeName) => typeName.Name + (!typeName.Name.ToLower().EndsWith("s") ? "s" : string.Empty);


        static public int GetNextSequenceValue<T>(IMongoDatabase db)
             where T : class, IEntity
        {
            var sequenceCollectionName = MongoHelper.GetCollectionName<Sequence>();
            string collectionName = MongoHelper.GetCollectionName<T>();

            var filter = Builders<Sequence>.Filter.Eq(x => x.Id, collectionName);
            var operation = Builders<Sequence>.Update.Inc(x => x.Value, 1);
            var newValue = db.GetCollection<Sequence>(sequenceCollectionName)
                             .FindOneAndUpdate(filter, operation, new FindOneAndUpdateOptions<Sequence> { ReturnDocument = ReturnDocument.After });

            if (newValue == null)
                throw new InvalidOperationException($"The sequence {collectionName} does not exist in Database. Application was not initialized properly.");

            return newValue.Value;
        }
    }
}
