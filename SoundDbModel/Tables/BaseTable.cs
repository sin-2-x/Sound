using SoundDatabase;
using SoundDatabase.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SoundDbModel.Tables
{
    public abstract class BaseTable<T> where T : BaseEntity
    {
        protected abstract DbSet<T> GetEntries(SoundDatabaseContext db);

        public abstract T CreateNewEntity();

        public ICollection<T> GetEntries()
        {
            List<T> d;
            using (var db = new SoundDatabaseContext(""))
            {
                var d1 = GetEntries(db);
                d = d1.ToList();
            }
            return d;
        }

        public void UpdateEntries(ICollection<BaseEntity> entriesToAdd, ICollection<BaseEntity> entriesToRemove, ICollection<BaseEntity> entriesToUpdate)
        {
            var usless = entriesToAdd.Intersect(entriesToRemove).ToArray();
            
            foreach (var entry in usless)
            {
                entriesToRemove.Remove(entry);
                entriesToUpdate.Remove(entry);
                entriesToAdd.Remove(entry);
            }

            usless = entriesToAdd.Intersect(entriesToUpdate).ToArray();

            foreach (var entity in usless)
            {
                entriesToUpdate.Remove(entity);
            }

            using (var db = new SoundDatabaseContext(""))
            {
                MarkEntries(db, entriesToAdd, EntityState.Added);
                MarkEntries(db, entriesToUpdate, EntityState.Modified);
                MarkEntries(db, entriesToRemove, EntityState.Deleted);

                db.SaveChanges();
            }
        }

        private void MarkEntries(SoundDatabaseContext db, ICollection<BaseEntity> entries, EntityState state)
        {
            foreach (var device in entries)
            {
                db.Entry(device).State = state;
            }
        }
    }
}
