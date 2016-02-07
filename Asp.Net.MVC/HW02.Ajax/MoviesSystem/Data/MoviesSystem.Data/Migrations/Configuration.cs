using System.Data.Entity.Migrations;
using System.Linq;
using MoviesSystem.Models;

namespace MoviesSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            for (int i = 0; i < 30; i++)
            {
                var movie = new Movie()
                {
                    Title = "Title " + (i + 1),
                    Year = 2000 + i,
                    Director = "Director  " + (i + 1),
                    LeadingMaleRole = new Actor()
                    {
                        Age = 22 + i,
                        Gender = GenderType.Male,
                        Name = "Actor " + (i + 1),

                        Studio = new Studio()
                        {
                            Address = "Studio Address " + (i + 1),
                            Name = "Studio Name " + (i + 1)
                        }
                    },
                    LeadingFemaleRole = new Actor()
                    {
                        Age = 32 + i,
                        Gender = GenderType.Female,
                        Name = "Actor " + (i + 1),

                        Studio = new Studio()
                        {
                            Address = "Studio Address " + (i + 32),
                            Name = "Studio Name " + (i + 32)
                        }
                    }
                };

                context.Movies.Add(movie);
            }
        }
    }
}
