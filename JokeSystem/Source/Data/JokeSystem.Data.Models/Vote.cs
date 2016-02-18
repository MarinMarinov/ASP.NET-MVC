namespace JokeSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }

        [Required]
        public int JokeId { get; set; }

        public virtual Joke Joke { get; set; }

        public VoteType Type { get; set; }
    }
}