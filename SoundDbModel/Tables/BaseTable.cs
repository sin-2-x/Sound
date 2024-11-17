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
            List<T> d;
            using (var db = new SoundDatabaseContext())
            {
                var d1 = GetEntries(db);
                d = d1.ToList();
            }
            return d;
        }

        public void UpdateEntries(ICollection<T> entriesToAdd, ICollection<T> entriesToRemove, ICollection<T> entriesToUpdate)
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

                /*if (entry is Device w)
                {
                    //Attach(db, entry);
                    //db.Entry(entry).State = state;
                    var o = db.Entry(w).State;
                    var o1 = db.Entry(w.DeviceWorkSession[0]).State;
                }*/
            }
        }
    }
}
