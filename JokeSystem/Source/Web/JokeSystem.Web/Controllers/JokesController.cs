namespace JokeSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using JokeSystem.Services.Data;
    using JokeSystem.Web.Infrastructure.Mapping;
    using JokeSystem.Web.ViewModels.Home;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokes;

        public JokesController(
            IJokesService jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult ById(string id)
        {
            var joke = this.jokes.GetById(id);
            var viewModel = this.Mapper.Map<JokeViewModel>(joke); // joke to JokeViewModel
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult ListJokes()
        {
            var viewModel = this.jokes.All().To<JokeViewModel>(); // map collection
            return this.View(viewModel);
        }
    }
}
