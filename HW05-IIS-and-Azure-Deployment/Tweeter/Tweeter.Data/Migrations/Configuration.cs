namespace Tweeter.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TweeterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TweeterDbContext context)
        {
            if (!context.Roles.Any())
            {
                this.SeedRoles(context);
            }

            if (!context.Users.Any())
            {
                this.SeedAdmin(context);
                this.SeedUsers(context);
            }

            if (!context.Tags.Any())
            {
                this.SeedTags(context);
            }

            if (!context.Tweets.Any())
            {
                this.SeedTwits(context);
            }
        }

        private void SeedRoles(TweeterDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = "admin" };

            manager.Create(role);
        }

        private void SeedAdmin(TweeterDbContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User { UserName = "admin@admin.com", Email = "admin@admin.com" };

            manager.Create(user, "Admin1"); // At least one capital letter and one digit
            manager.AddToRole(user.Id, "admin");
        }

        private void SeedUsers(TweeterDbContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);

            for (int i = 0; i < 10; i++)
            {
                var name = string.Format("user{0}@mail.bg", i);
                var user = new User { 
                    UserName = name,
                    Email = name
                };

                manager.Create(user, "User123"); // At least one capital letter and one digit
            }

            context.SaveChanges();
        }

        private void SeedTags(TweeterDbContext context)
        {

            for (int i = 0; i < 20; i++)
            {
                context.Tags.Add(new Tag
                {
                    Name = "#tagname" + i
                });
            }

            context.Tags.Add(new Tag { Name = "#fail" });
            context.SaveChanges();
        }

        private void SeedTwits(TweeterDbContext context)
        {
            var random = new Random().Next(0, 10);
            var allUsers = context.Users.ToList();
            var allTags = context.Tags.ToList();

            for (int i = 0; i < 100; i++)
            {
                var tweet = new Tweet
                {
                    Author = GetRandomFrom(allUsers),
                    Message = string.Format("Message {0} Ala bala {1} portokala {2}", i, i, i)
                };

                var randomTags = GetRandomsFrom(allTags);
                foreach (var tag in randomTags)
                {
                    tweet.Tags.Add(tag);
                }

                context.Tweets.Add(tweet);
            }

            context.SaveChanges();
        }
        
        private T GetRandomFrom<T>(IList<T> collection)
        {
            var index = new Random().Next(0, collection.Count);
            return collection[index];
        }

        private static ICollection<T> GetRandomsFrom<T>(IList<T> collection)
        {
            var random = new Random();
            var numberOfItems = random.Next(1, collection.Count);
            var collectionToReturn = new HashSet<T>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var index = random.Next(0, collection.Count);
                collectionToReturn.Add(collection[index]);
            }

            return collectionToReturn;
        }
    }
}
