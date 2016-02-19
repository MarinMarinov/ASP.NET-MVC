namespace JokeSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AutoMapper;
    using JokeSystem.Data.Models;
    using JokeSystem.Services.Web;
    using JokeSystem.Web.Infrastructure.Mapping;
    using System.Linq;

    public class JokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                //return $"/Joke/{identifier.EncodeId(this.Id)}";
                return string.Format("/Joke/{0}/nekakvaTapotia", identifier.EncodeId(this.Id));

                //return string.Format("/Joke/{0}/vtoraTapotia", this.Id);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(jvm => jvm.Category, opt => opt.MapFrom(j => j.Category.Name))
                .ForMember(jvm => jvm.VotesCount, opt => opt.MapFrom(j => j.Votes.Any() ? j.Votes.Sum(jv => (int)jv.VoteType) : 0));
        }
    }
}
