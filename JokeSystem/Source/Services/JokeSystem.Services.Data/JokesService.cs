namespace JokeSystem.Services.Data
{
    using System;
    using System.Linq;

    using JokeSystem.Data.Common;
    using JokeSystem.Data.Models;
    using JokeSystem.Services.Web;

    public class JokesService : IJokesService
    {
        private readonly IDbRepository<Joke> jokes;
        private readonly IIdentifierProvider identifierProvider;

        public JokesService(IDbRepository<Joke> jokes, IIdentifierProvider identifierProvider)
        {
            this.jokes = jokes;
            this.identifierProvider = identifierProvider;
        }

        public Joke GetById(string id)
        {
            //var intId = this.identifierProvider.DecodeId(id);
            //var joke = this.jokes.GetById(intId);
            var joke = this.jokes.GetById(int.Parse(id));
            return joke;
        }

        public IQueryable<Joke> All()
        {
            return this.jokes.All().OrderBy(j => j.Id);
        }

        public IQueryable<Joke> GetRandomJokes(int count)
        {
            return this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
