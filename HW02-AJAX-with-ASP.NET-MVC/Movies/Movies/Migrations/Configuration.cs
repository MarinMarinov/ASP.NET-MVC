namespace Movies.Migrations
{
    using Data;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            var movieOne = new Movie
            {
                Title = "Episode IV: A New Hope",
                Director = "George Lucas",
                Year = 1977,
                LeadingMaleRoleActor = "Harrison Ford",
                LeadingFemaleRoleActress = "Carrie Fisher",
                ActorAge = 35,
                ActressAge = 21,
                Studio = "Lucasfilm Ltd.",
                StudioAddress = "Letterman Digital Arts Center (Presidio of San Francisco), California, U.S."
            };

            var movieTwo = new Movie
            {
                Title = "Episode V: The Empire Strikes Back",
                Director = "George Lucas",
                Year = 1980,
                LeadingMaleRoleActor = "Harrison Ford",
                LeadingFemaleRoleActress = "Carrie Fisher",
                ActorAge = 38,
                ActressAge = 24,
                Studio = "Lucasfilm Ltd.",
                StudioAddress = "Letterman Digital Arts Center (Presidio of San Francisco), California, U.S."
            };

            var movieThree = new Movie
            {
                Title = "Episode VI: Return of the Jedi",
                Director = "George Lucas",
                Year = 1983,
                LeadingMaleRoleActor = "Harrison Ford",
                LeadingFemaleRoleActress = "Carrie Fisher",
                ActorAge = 41,
                ActressAge = 27,
                Studio = "Lucasfilm Ltd.",
                StudioAddress = "Letterman Digital Arts Center (Presidio of San Francisco), California, U.S."
            };

            context.Movies.Add(movieOne);
            context.Movies.Add(movieTwo);
            context.Movies.Add(movieThree);

            context.SaveChanges();
        }
    }
}
