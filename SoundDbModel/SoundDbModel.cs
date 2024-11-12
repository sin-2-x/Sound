using SoundDatabase;
using SoundDatabase.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbModel
{
    public class SoundDbModel
    {
        SoundDatabaseContext db;

        public SoundDbModel() {
            db = new SoundDatabaseContext(ConnectionString); 
        }
        public string ConnectionString { get; set; }

        public List<Device> GetDevices()
        {
            List<Device> d;
            //using (var db = new SoundDatabaseContext(ConnectionString))
            {
                d = db.Devices.ToList();
            }
            return d.ToList();
        }

        public List<WorkSession> GetWorlSessions()
        {
            List<WorkSession> d;
            //using (var db = new SoundDatabaseContext(ConnectionString))
            {
                d = db.WorkSessions.ToList();
            }
            return d.ToList();
        }

        public void Save() {
            //using (var db = new SoundDatabaseContext(ConnectionString))
            {
                db.SaveChanges();
            }
        }
    }
}
