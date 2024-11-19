using SoundDatabase.DataModel;
using SoundDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundDbModel.Tables
{
    public class AudioSignalTable : BaseTable<AudioSignal>
    {

        protected override IQueryable<AudioSignal> GetEntries(SoundDatabaseContext c)
        {
            return c.AudioSignals;
        }

        public override AudioSignal CreateNewEntity()
        {
            return new AudioSignal();
        }

        protected override void Attach(SoundDatabaseContext db, AudioSignal entry)
        {
            // entry = db.Devices.FirstOrDefault(x => x.Id == entry.Id);

            //db.Devices.Attach(entry);
            //db.Devices.Include(o => o.DeviceWorkSession);

            //db.Entry(entry).Collection(o=>o.DeviceWorkSession).Load();
        }
    }
}
