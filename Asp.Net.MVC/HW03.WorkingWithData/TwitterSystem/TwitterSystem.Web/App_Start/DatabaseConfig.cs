using System.Data.Entity;
using TwitterSystem.Data;
using TwitterSystem.Data.Migrations;

namespace TwitterSystem.Web
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}