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

        public SoundDatabaseContext(string h)
            : base($"Host={"127.0.0.1"};Port={5432};Database={"SoundDatabase"};Username={"postgres"};Password={"root"};")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SoundDatabaseContext, Configuration>(true));

            Database.CreateIfNotExists();
            //connectionconfig = $"Host={host};Port={port};Database={databaseName};Username={login};Password={password};";
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UhfDatabaseContext, Configuration>(true));
        }

        /*public SoundDatabaseContext()
            : base($"Host={"127.0.0.1"};Port={5432};Database={"SoundDatabase"};Username={"postgres"};Password={"root"};")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SoundDatabaseContext, Configuration>(true));
            //connectionconfig = $"Host={host};Port={port};Database={databaseName};Username={login};Password={password};";
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UhfDatabaseContext, Configuration>(true));
        }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<AnalyzeSession>().HasRequired(a => a.AudioSignal);


            modelBuilder.Entity<Device>().HasKey(i => i.Id);
        }

        //public SoundDatabaseContext() => Database.EnsureCreated();

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionconfig);
        }*/
    }
}
