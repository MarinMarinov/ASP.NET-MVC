namespace JokeSystem.Data.Models
{
    using System.Collections.Generic;

    using JokeSystem.Data.Common.Models;

    public class JokeCategory : BaseModel
    {
        public JokeCategory()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
