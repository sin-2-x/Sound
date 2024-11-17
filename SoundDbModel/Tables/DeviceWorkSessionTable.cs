using SoundDatabase.DataModel;
using SoundDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbModel.Tables
{
    public class DeviceWorkSessionTable : BaseTable<DeviceWorkSession>
    {

        protected override IQueryable<DeviceWorkSession> GetEntries(SoundDatabaseContext c)
        {
            return c.DeviceWorkSessions;
        }

        public override DeviceWorkSession CreateNewEntity()
        {
            return new DeviceWorkSession();
        }

        protected override void Attach(SoundDatabaseContext db, DeviceWorkSession entry)
        {
            //db.DeviceWorkSessions.Attach(entry);
            //db.DeviceWorkSessions.Include(m => m.Device);
            //db.Devices.Attach(entry.Device);
            //db.Devices.Include(o => o.DeviceWorkSession); 
            //db.Entry(entry.Device).Collection(o => o.DeviceWorkSession).Load();
            //db.WorkSessions.Attach(entry.Device);
        }
    }
}
