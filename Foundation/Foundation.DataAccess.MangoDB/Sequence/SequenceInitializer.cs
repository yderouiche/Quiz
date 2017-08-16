using MongoDB.Driver;
using System;
using System.Linq;

namespace Foundation.DataAccess.MongoDB
{
    public class MongoDBBootstrapper
    {

        public static void SequenceInitializer(string connection, string databaseName, params Type[] types)
        {
            var client = new MongoClient($"{connection}/{databaseName}");
            var db = client.GetDatabase(databaseName);

            var sequenceCollectionName = MongoHelper.GetCollectionName<Sequence>();

            foreach (Type type in types)
            {
                var CollectionName = MongoHelper.GetCollectionName(type);
                if (!db.GetCollection<Sequence>(sequenceCollectionName).AsQueryable().Where(x => x.Id == CollectionName).Any())
                    db.GetCollection<Sequence>(sequenceCollectionName).InsertOne(new Sequence { Id = CollectionName, Value = 0 });
            }
        }
    }
}
