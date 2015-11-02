namespace ArtistSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<ArtistSystemDbContext>
    {
        public Configuration()
        {
            // TODO: Set to FALSE in production
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ArtistSystemDbContext context)
        {
        }
    }
}