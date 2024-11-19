using SoundDatabase;
using SoundDatabase.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbFiller
{
    internal class Program
    {
        static Random rnd = new Random(DateTime.Now.Second);
        private static SoundDatabaseContext db;
        public static void Main() {

            db = new SoundDatabaseContext();
            FillDevices(db.Devices);
            db.SaveChanges();
            FillWorksessions(db.WorkSessions);
            db.SaveChanges();
            FillDeviceWorksessions();
            db.SaveChanges();
            FillAudioSignals();
            db.SaveChanges();
        }

        private static void FillDevices(DbSet<Device> dbSet) {

            for (int i = 0; i < 20; i++)
            {
                var model = new Device();

                var name = $"{rnd.Next(1, 100)}-{rnd.Next(1, 100)}-{rnd.Next(1, 100)}-{rnd.Next(1, 100)}";
                model.Name = name;
                dbSet.Add(model);
            }
        }

        private static void FillWorksessions(DbSet<WorkSession> dbSet)
        {

            for (int i = 0; i < 20; i++)
            {
                var model = new WorkSession();

                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                var s = start.AddDays(rnd.Next(range));
                var e = start.AddDays(rnd.Next(range));
                model.TimeStart = s;
                model.TimeStop = e;
                dbSet.Add(model);
            }
        }

        private static void FillDeviceWorksessions()
        {

            for (int i = 0; i < 20; i++)
            {
                var indecD = rnd.Next(0, db.Devices.ToList().Count);
                var indecW = rnd.Next(0, db.WorkSessions.ToList().Count);
                var model = new DeviceWorkSession();
                model.WorkSessionId = db.WorkSessions.ToList()[indecW].Id;
                model.DeviceId = db.Devices.ToList()[indecD].Id;

                db.DeviceWorkSessions.Add(model);
            }
        }

        private static void FillAudioSignals()
        {

            for (int i = 0; i < 20; i++)
            {

                var indecDW = rnd.Next(0, db.DeviceWorkSessions.ToList().Count);
                var model = new AudioSignal();

                model.DeviceWorkSessionId = db.DeviceWorkSessions.ToList()[indecDW].Id;

                db.AudioSignals.Add(model);
            }
        }
    }
}
