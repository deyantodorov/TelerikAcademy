using System.Data.Entity;
using MoviesSystem.Data;
using MoviesSystem.Data.Migrations;

namespace MoviesSystem.Web
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}
