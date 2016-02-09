namespace Movies.Data
{
    using System.Data.Entity;

    public class MoviesDbContext : DbContext
    {

        public MoviesDbContext()
            : base("MoviesDbContext")
        {
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }
    }
}