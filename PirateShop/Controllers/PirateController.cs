using System.Web.Mvc;

namespace PirateShop.Controllers
{
    public class PirateController : Controller
    {
        // GET: Pirate
        public ActionResult Index()
        {
            return View("Create");
        }
    }
}