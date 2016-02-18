namespace JokeSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using JokeSystem.Data.Common.Models;

    public class Feedback : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
