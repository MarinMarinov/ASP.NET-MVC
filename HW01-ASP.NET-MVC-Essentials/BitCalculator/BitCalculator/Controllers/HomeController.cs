using System.Web.Mvc;

namespace BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int qt, long type)
        {
            long bits = qt * type;

            return this.Content(
                @"<table class=""table table-striped table-condensed"">
                    <tr><td width=""120"">Bit</td><td width=""150"">" + bits + @"</td></tr>
                    <tr><td width=""120"">Byte</td><td width=""150"">" + bits / 8d + @"</td></tr>
                    <tr><td width=""120"">Kilobit</td><td width=""150"">" + bits / 1024d + @"</td></tr>
                    <tr><td width=""120"">Kilobyte</td><td width=""150"">" + bits / 8192d + @"</td></tr>
                    <tr><td width=""120"">Megabit</td><td width=""150"">" + bits / 1048576d + @"</td></tr>
                    <tr><td width=""120"">Megabyte</td><td width=""150"">" + bits / 8388608d + @"</td></tr>
                    <tr><td width=""120"">Gigabit</td><td width=""150"">" + bits / 1073741824d + @"</td></tr>
                    <tr><td width=""120"">Gigabyte</td><td width=""150"">" + bits / 8589934592d + @"</td></tr>
                    <tr><td width=""120"">Terabit</td><td width=""150"">" + bits / 1099511627776d + @"</td></tr>
                    <tr><td width=""120"">Terabyte</td><td width=""150"">" + bits / 8796093022208d + @"</td></tr>
                    <tr><td width=""120"">Petabit</td><td width=""150"">" + bits / 1125899906842624d + @"</td></tr>
                    <tr><td width=""120"">Petabyte</td><td width=""150"">" + bits / 9007199254740992d + @"</td></tr>
                    <tr><td width=""120"">Exabit</td><td width=""150"">" + bits / 1152921504606846976d + @"</td></tr>
                    <tr><td width=""120"">Exabyte</td><td width=""150"">" + bits / 9.2233720368548E+18 + @"</td></tr>
                    <tr><td width=""120"">Zettabit</td><td width=""150"">" + bits / 1.1805916207174E+21d + @"</td></tr>
                </table>"
                );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}