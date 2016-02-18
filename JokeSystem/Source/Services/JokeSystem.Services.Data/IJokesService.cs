namespace JokeSystem.Services.Data
{
    using System.Linq;

    using JokeSystem.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);

        IQueryable<Joke> All();
    }
}
