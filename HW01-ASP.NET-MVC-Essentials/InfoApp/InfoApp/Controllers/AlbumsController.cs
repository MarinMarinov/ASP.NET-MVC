using System.Web.Mvc;

namespace InfoApp.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Albums
        public ActionResult Index(string year)
        {
            this.ViewBag.Year = year;
            return View();
        }
    }
}