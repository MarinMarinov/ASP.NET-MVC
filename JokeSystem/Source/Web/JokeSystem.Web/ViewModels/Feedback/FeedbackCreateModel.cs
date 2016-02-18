namespace JokeSystem.Web.ViewModels.Feedback
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class FeedbackCreateModel
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }
    }
}