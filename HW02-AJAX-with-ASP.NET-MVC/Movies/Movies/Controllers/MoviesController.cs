using System.Linq;
using System.Web.Mvc;

namespace Movies.Controllers
{
    using Data;
    using Models;
    using System.Net;

    public class MoviesController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();

        // GET: Movies
        public ActionResult AllMovies()
        {
            var movies = this.db.Movies.Select(AllMoviesModel.FromMovies).OrderBy(m => m.Year).ToList();

            return View(movies);
        }

        public ActionResult Search(string query)
        {
            var result = this.db.Movies
                .Where(m => m.Title.ToLower().Contains(query.ToLower()))
                .Select(AllMoviesModel.FromMovies)
                .ToList();

            return View("_MovieSearchResults", result);
        }

        public ActionResult MovieDetailsById(int id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var movie =
                this.db.Movies
                .Where(m => m.Id == id)
                .Select(AllMoviesModel.FromMovies)
                .FirstOrDefault();

            if (movie == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Movie not found");
            }

            return this.PartialView("_MovieDetails", movie);
        }

        [HttpGet]
        public ActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(AllMoviesModel model)
        {
            if (ModelState.IsValid)
            {
                this.db.Movies.Add(new Movie
                {
                    Title = model.Title,
                    Director = model.Director,
                    Year = model.Year,
                    LeadingMaleRoleActor = model.LeadingMaleRoleActor,
                    ActorAge = model.ActorAge,
                    LeadingFemaleRoleActress = model.LeadingFemaleRoleActress,
                    ActressAge = model.ActressAge,
                    Studio = model.Studio,
                    StudioAddress = model.StudioAddress
                });

                this.db.SaveChanges();

                TempData["Success"] = "You have successfully created new movie";

                return RedirectToAction("CreateMovie");
            }

            return View("CreateMovie", model);
        }
    }
}