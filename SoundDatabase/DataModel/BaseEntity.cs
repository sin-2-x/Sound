using System;

namespace SoundDatabase.DataModel
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var entity = obj as BaseEntity;
            if (entity != null)
            {
                return Equals(entity);
            }
            return false;
        }

        protected bool Equals(BaseEntity other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
