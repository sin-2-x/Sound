using SoundDatabase.DataModel;
using SoundDatabase;
using System.Data.Entity;

namespace SoundDbModel.Tables
{
    public class DevicesTable : BaseTable<Device>
    {

        protected override DbSet<Device> GetEntries(SoundDatabaseContext c)
        {
            return c.Devices;
        }

        public override Device CreateNewEntity()
        {
            return new Device();
        }
    }
}
