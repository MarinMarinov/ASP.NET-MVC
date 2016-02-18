namespace JokeSystem.Data.Models
{
    using System.Collections.Generic;
    using Common.Models;

    public class Tag : BaseModel
    {
        public Tag()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
