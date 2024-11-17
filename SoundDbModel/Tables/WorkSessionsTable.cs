using SoundDatabase;
using SoundDatabase.DataModel;
using System.Data.Entity;
using System.Linq;

namespace SoundDbModel.Tables
{
    public class WorkSessionsTable : BaseTable<WorkSession>
    {
        protected override IQueryable<WorkSession> GetEntries(SoundDatabaseContext c)
        {
            return c.WorkSessions;
        }

        public override WorkSession CreateNewEntity()
        {
            return new WorkSession();
        }
        protected override void Attach(SoundDatabaseContext db, WorkSession entriy)
        {

        }
    }
}
