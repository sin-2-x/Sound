using SoundDatabase;
using SoundDatabase.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SoundDbModel.Tables
{
    public abstract class BaseTable<T> where T : BaseEntity
    {
        protected abstract IQueryable<T> GetEntries(SoundDatabaseContext db);

        public abstract T CreateNewEntity();

        public ICollection<T> GetEntries()
        {
            using (var db = new SoundDatabaseContext())
            {
                var d1 = GetEntries(db);
                return d1.ToList();
            }
        }

        public void UpdateEntries(ICollection<T> entriesToAdd, ICollection<T> entriesToRemove, ICollection<T> entriesToUpdate)
        {
            var useless = entriesToAdd.Intersect(entriesToRemove).ToArray();

            foreach (var entry in useless)
            {
                entriesToRemove.Remove(entry);
                entriesToUpdate.Remove(entry);
                entriesToAdd.Remove(entry);
            }

            useless = entriesToAdd.Intersect(entriesToUpdate).ToArray();

            foreach (var entity in useless)
            {
                entriesToUpdate.Remove(entity);
            }

            using (var db = new SoundDatabaseContext())
            {
                MarkEntries(db, entriesToAdd, EntityState.Added);
                MarkEntries(db, entriesToUpdate, EntityState.Modified);
                MarkEntries(db, entriesToRemove, EntityState.Deleted);

                db.SaveChanges();
            }
        }

        protected abstract void Attach(SoundDatabaseContext db, T entry);

        private void MarkEntries(SoundDatabaseContext db, ICollection<T> entries, EntityState state)
        {
            foreach (var entry in entries)
            {
                Attach(db, entry);
                db.Entry(entry).State = state;
            }
        }
    }
}
