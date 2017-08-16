namespace Foundation.Domain.Entity
{
    public abstract class EntityBase : IEntity
    { 
        public EntityBase() { }

        public int? Id { get; set; }

        public bool IsNew
        {
            get
            {
                return !Id.HasValue;
            }
        }

        public override string ToString()
        {
            return $"(id: {Id})";
        }
    }
}
