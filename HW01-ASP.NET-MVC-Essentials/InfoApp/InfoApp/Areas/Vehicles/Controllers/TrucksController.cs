using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoApp.Areas.Vehicles.Controllers
{
    public class TrucksController : Controller
    {
        // GET: Vehicles/Trucks
        public ActionResult Index()
        {
            return View();
        }
    }
}