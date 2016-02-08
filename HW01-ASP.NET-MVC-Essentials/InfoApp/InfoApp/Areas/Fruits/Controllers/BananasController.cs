using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoApp.Areas.Fruits.Controllers
{
    public class BananasController : Controller
    {
        // GET: Fruits/Bananas
        public ActionResult Index()
        {
            return View();
        }
    }
}