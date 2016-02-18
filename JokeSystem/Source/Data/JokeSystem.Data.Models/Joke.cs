namespace JokeSystem.Data.Models
{
    using System.Collections.Generic;
    using JokeSystem.Data.Common.Models;

    public class Joke : BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual JokeCategory Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
