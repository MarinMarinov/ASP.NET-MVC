namespace JokeSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JokeSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            PasswordHasher hasher = new PasswordHasher();
            Random random = new Random();
            var users = new List<User>();

            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any())
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                var admin = new User
                {
                    UserName = "admin@mail.bg",
                    Email = "admin@mail.bg",
                    PhoneNumber = "+3591234569",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword("1")
                };
                users.Add(admin);
                context.Users.Add(admin);
                context.SaveChanges();
                manager.AddToRole(admin.Id, "admin");

                User tosho = new User
                {
                    UserName = "tosho@mail.bg",
                    Email = "tosho@mail.bg",
                    PhoneNumber = "+3591234569",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword("1")
                };

                User pesho = new User
                {
                    UserName = "pesho@mail.bg",
                    Email = "pesho@mail.bg",
                    PhoneNumber = "+3591234569",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword("1")
                };

                users.Add(tosho);
                users.Add(pesho);
                context.Users.AddOrUpdate(users.ToArray());
                context.SaveChanges();
            }

            if (!context.Jokes.Any())
            {
                Crawler.Craw(context);
            }

            var tagList = new List<Tag>();
            var jokes = context.Jokes.Where(j => !j.IsDeleted).ToList();
            if (!context.Tags.Any())
            {
                for (var i = 0; i < 20; i++)
                {
                    var randomJokes = jokes.GetRange(i * 5, 5); // beware for seeding exactly 100 jokes
                    for (var j = 0; j < 5; j++)
                    {
                        var tag = new Tag
                        {
                            Name = string.Format("The {0}-th five", i),
                            Jokes = randomJokes
                        };

                        tagList.Add(tag);
                    }
                }

                context.Tags.AddOrUpdate(tagList.ToArray());
            }

            var feedList = new List<Feedback>();
            if (!context.Feedback.Any())
            {
                for (var i = 0; i < 30; i++)
                {
                    var content = string.Format("<b>{0}Ala-bala{1}</b> proba {2}", i, i, i);
                    if (i % 5 == 0)
                    {
                        content = string.Format(
                            "<a onclick=\"alert('You, have been Hacked')\" ><b>{0}Ala-bala{1}</b></a> proba {2}",
                            i,
                            i,
                            i);
                    }

                    var randomNumber = random.Next(3);
                    var feedBack = new Feedback
                    {
                        Title = "Feedback " + i,
                        Content = content,
                        Author = users[randomNumber]
                    };

                    feedList.Add(feedBack);
                }

                context.Feedback.AddOrUpdate(feedList.ToArray());
            }

            context.SaveChanges();
        }
    }
}
