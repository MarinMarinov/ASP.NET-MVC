namespace JokeSystem.Web.ViewModels.Feedback
{
    using System;

    using AutoMapper;
    using Ganss.XSS;

    using JokeSystem.Data.Models;
    using JokeSystem.Web.Infrastructure.Mapping;
    using JokeSystem.Web.Infrastructure.Sanitizer;

    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        private ISanitizer sanitizer;

        public FeedbackViewModel()
        {
            this.sanitizer = new HtmlSanitizerModule();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string SanitizedContent
        {
            get
            {
                return this.sanitizer.Sanitize(this.Content);
            }
        }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(fbvm => fbvm.Author, opt => opt.MapFrom(fb => fb.Author.UserName));
        }
    }
}
