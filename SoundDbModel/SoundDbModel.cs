using SoundDatabase;
using SoundDatabase.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SoundDbModel
{
    public class SoundDbModel
    {
        public SoundDatabaseContext db;

        public SoundDbModel()
        {
            db = new SoundDatabaseContext(ConnectionString);
        }
        public string ConnectionString { get; set; }

        public ICollection<Device> GetDevices()
        {
            List<Device> d;
            using (var db = new SoundDatabaseContext(ConnectionString))
            {
                d = db.Devices.ToList();
            }
            return db.Devices.ToList();
        }

        public void UpdateDevices(ICollection<Device> devicesToAdd, ICollection<Device> devicesToRemove, ICollection<Device> devicesToUpdate)
        {
            foreach (var device in devicesToRemove)
            {
                devicesToAdd.Remove(device);
                devicesToUpdate.Remove(device);
            }

            using (var db = new SoundDatabaseContext(ConnectionString))
            {
                foreach (var device in devicesToAdd)
                {
                    db.Entry(device).State = EntityState.Added;
                }                
                foreach (var device in devicesToUpdate)
                {
                    db.Entry(device).State = EntityState.Modified;
                }
                foreach (var device in devicesToRemove)
                {
                    db.Entry(device).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }

        public List<WorkSession> GetWorlSessions()
        {
            List<WorkSession> d;
            using (var db = new SoundDatabaseContext(ConnectionString))
            {
                d = db.WorkSessions.ToList();
            }
            return d.ToList();
        }

        public void Save()
        {
            using (var db = new SoundDatabaseContext(ConnectionString))
            {
                db.SaveChanges();
            }
        }
    }
}
