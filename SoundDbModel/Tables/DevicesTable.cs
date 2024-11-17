using SoundDatabase.DataModel;
using SoundDatabase;
using System.Data.Entity;
using System.Linq;

namespace SoundDbModel.Tables
{
    public class DevicesTable : BaseTable<Device>
    {

        protected override IQueryable<Device> GetEntries(SoundDatabaseContext c)
        {
            return c.Devices.Include(o => o.DeviceWorkSession);
        }

        public override Device CreateNewEntity()
        {
            return new Device();
        }

        protected override void Attach(SoundDatabaseContext db, Device entry)
        {
            // entry = db.Devices.FirstOrDefault(x => x.Id == entry.Id);

            //db.Devices.Attach(entry);
            //db.Devices.Include(o => o.DeviceWorkSession);

            //db.Entry(entry).Collection(o=>o.DeviceWorkSession).Load();
        }
    }
}
