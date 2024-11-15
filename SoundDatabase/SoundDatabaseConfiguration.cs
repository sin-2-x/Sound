using System.Data.Entity;

namespace SoundDatabase
{
    internal class SoundDatabaseConfiguration : DbConfiguration
    {
        public SoundDatabaseConfiguration()
        {
            SetProviderServices("Npgsql", Npgsql.NpgsqlServices.Instance);
            SetProviderFactory("Npgsql", Npgsql.NpgsqlFactory.Instance);
            SetDefaultConnectionFactory(new Npgsql.NpgsqlConnectionFactory());
        }
    }
}
