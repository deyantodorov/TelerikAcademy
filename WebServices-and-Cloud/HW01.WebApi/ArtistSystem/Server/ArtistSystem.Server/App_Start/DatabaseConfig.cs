namespace ArtistSystem.Server
{
    using System.Data.Entity;
    using ArtistSystem.Data;
    using ArtistSystem.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistSystemDbContext, Configuration>());
        }
    }
}
