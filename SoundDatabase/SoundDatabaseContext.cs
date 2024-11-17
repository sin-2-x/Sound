using SoundDatabase.DataModel;
using SoundDatabase.Migrations;
using System.Data.Entity;

namespace SoundDatabase
{

    public class SoundDatabaseContext : DbContext
    {
        private readonly string connectionconfig;

        public DbSet<Device> Devices => Set<Device>();
        public DbSet<AnalyzeSession> AnalyzeSessions => Set<AnalyzeSession>();
        public DbSet<AnalyzeSessionResult> AnalyzeSessionsResults => Set<AnalyzeSessionResult>();
        public DbSet<AudioSignal> AudioSignals => Set<AudioSignal>();
        public DbSet<WorkSession> WorkSessions => Set<WorkSession>();
        public DbSet<DeviceWorkSession> DeviceWorkSessions => Set<DeviceWorkSession>();

        public SoundDatabaseContext()
            : base($"Host={"127.0.0.1"};Port={5432};Database={"SoundDatabase"};Username={"postgres"};Password={"root"};")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SoundDatabaseContext, Configuration>(true));

            Database.CreateIfNotExists();

            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalyzeSession>().HasRequired(a => a.AudioSignal);
            
            modelBuilder.Entity<Device>().HasMany(i => i.DeviceWorkSession).WithOptional(i => i.Device).HasForeignKey(i => i.DeviceId);
            modelBuilder.Entity<WorkSession>().HasMany(i => i.DeviceWorkSessions).WithOptional(i => i.WorkSession).HasForeignKey(i => i.WorkSessionId);

            //modelBuilder.Entity<DeviceWorkSession>().HasOptional(i => i.Device).WithMany(i=>i.DeviceWorkSession).HasForeignKey(i=>i.DeviceId).WillCascadeOnDelete(false);
            
        }
    }
}
