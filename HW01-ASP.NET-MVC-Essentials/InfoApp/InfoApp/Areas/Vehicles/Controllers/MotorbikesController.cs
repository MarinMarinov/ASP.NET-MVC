using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoApp.Areas.Vehicles.Controllers
{
    public class MotorbikesController : Controller
    {
        // GET: Vehicles/Motorbikes
        public ActionResult Index()
        {
            return View();
        }
    }
}