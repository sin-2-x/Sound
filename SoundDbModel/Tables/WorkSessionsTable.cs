using SoundDatabase;
using SoundDatabase.DataModel;
using System.Data.Entity;

namespace SoundDbModel.Tables
{
    public class WorkSessionsTable : BaseTable<WorkSession>
    {
        protected override DbSet<WorkSession> GetEntries(SoundDatabaseContext c)
        {
            return c.WorkSessions;
        }

        public override WorkSession CreateNewEntity()
        {
            return new WorkSession();
        }
    }
}
