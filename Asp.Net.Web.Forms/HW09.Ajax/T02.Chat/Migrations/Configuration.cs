using System.Data.Entity.Migrations;
using T02.Chat.Data;

namespace T02.Chat.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ChatDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}