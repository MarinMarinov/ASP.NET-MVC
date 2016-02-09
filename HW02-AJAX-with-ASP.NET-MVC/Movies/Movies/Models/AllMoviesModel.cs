namespace Movies.Models
{
    using Data;
    using System;
    using System.Linq.Expressions;

    public class AllMoviesModel
    {
        public static Expression<Func<Movie, AllMoviesModel>> FromMovies
        {
            get
            {
                return movie => new AllMoviesModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Year = movie.Year,
                    LeadingMaleRoleActor = movie.LeadingMaleRoleActor,
                    ActorAge = movie.ActorAge,
                    LeadingFemaleRoleActress = movie.LeadingFemaleRoleActress,
                    ActressAge = movie.ActressAge,
                    Studio = movie.Studio,
                    StudioAddress = movie.StudioAddress
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public string LeadingMaleRoleActor { get; set; }

        public string LeadingFemaleRoleActress { get; set; }

        public int ActorAge { get; set; }

        public int ActressAge { get; set; }

        public string Studio { get; set; }

        public string StudioAddress { get; set; }
    }
}