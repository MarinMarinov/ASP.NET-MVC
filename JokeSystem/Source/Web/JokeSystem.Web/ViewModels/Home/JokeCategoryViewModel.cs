namespace JokeSystem.Web.ViewModels.Home
{
    using JokeSystem.Data.Models;
    using JokeSystem.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
