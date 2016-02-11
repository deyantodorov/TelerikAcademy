using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TwitterSystem.Common;
using TwitterSystem.Models;

namespace TwitterSystem.Data.Migrations
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
            var randomGenerator = new RandomGenerator();

            SeedRoles(context);
            SeedAdministrator(context);
            SeedUsers(context);
            SeedTweets(context, randomGenerator);
            SeedComments(context, randomGenerator);
        }

        private void SeedComments(ApplicationDbContext context, RandomGenerator randomGenerator)
        {
            if (context.Comments.Any())
            {
                return;
            }

            var tweets = context.Tweets.Where(x => x.IsVisible).ToList();
            var users = context.Users.OrderBy(x => x.Id).ToList();

            for (int i = 0; i < 10; i++)
            {
                var comment = new Comment()
                {
                    TweetId = tweets[i].Id,
                    Content = randomGenerator.GetRandowSentance(2, 100),
                    CreatedOn = randomGenerator.GetRandomDate(DateTime.Now.AddYears(-i), DateTime.Now),
                    IsVisible = true,
                    UserId = users[i].Id
                };

                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }

        private void SeedTweets(ApplicationDbContext context, RandomGenerator randomGenerator)
        {

            if (context.Tweets.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var userName = (i + 1) + GlobalConstants.FakeUserMail;

                var tweet = new Tweet()
                {
                    Content = randomGenerator.GetRandowSentance(2, 250),
                    CreatedOn = randomGenerator.GetRandomDate(DateTime.Now.AddYears(-i), DateTime.Now),
                    IsVisible = true,
                    UserId = context.Users.First(x => x.UserName == userName).Id
                };

                tweet.Tags.Add(new Tag()
                {
                    IsVisible = true,
                    Name = "tag" + i
                });

                context.Tweets.Add(tweet);
                context.SaveChanges();
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Count() > 1)
            {
                return;
            }

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store)
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                }
            };

            for (int i = 0; i < 10; i++)
            {
                var user = new User()
                {
                    UserName = (i + 1) + GlobalConstants.FakeUserMail,
                    Email = (i + 1) + GlobalConstants.FakeUserMail
                };

                manager.Create(user, GlobalConstants.FakeUserPass);
            }

            context.SaveChanges();
        }

        private void SeedAdministrator(ApplicationDbContext context)
        {
            if (context.Users.Any(u => u.UserName == GlobalConstants.AdminMail))
            {
                return;
            }

            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store)
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                }
            };

            var admin = new User()
            {
                UserName = GlobalConstants.AdminMail,
                Email = GlobalConstants.AdminMail
            };

            manager.Create(admin, GlobalConstants.AdminPass);
            context.SaveChanges();

            manager.AddToRole(admin.Id, GlobalConstants.AdminRole);
            context.SaveChanges();
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                return;
            }

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var administrator = new IdentityRole(GlobalConstants.AdminRole);

            manager.Create(administrator);
        }
    }
}