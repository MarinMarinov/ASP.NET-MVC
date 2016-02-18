namespace JokeSystem.Services.Data
{
    using System.Linq;

    using JokeSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
