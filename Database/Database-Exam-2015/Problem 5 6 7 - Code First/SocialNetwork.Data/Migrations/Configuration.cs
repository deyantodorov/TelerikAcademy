namespace SocialNetwork.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetworkDbContext>
    {
        public Configuration()
        {
            // TODO: Set both to False in production
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SocialNetworkDbContext context)
        {
        }
    }
}
