namespace JokeSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AutoMapper;
    using JokeSystem.Data.Models;
    using JokeSystem.Services.Web;
    using JokeSystem.Web.Infrastructure.Mapping;

    public class JokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                //return $"/Joke/{identifier.EncodeId(this.Id)}";
                //return string.Format("/Joke/{0}/nekakvaTapotia", identifier.EncodeId(this.Id));

                return string.Format("/Joke/{0}/vtoraTapotia", this.Id);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
