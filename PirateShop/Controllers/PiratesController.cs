using System.Web.Mvc;

namespace PirateShop.Controllers
{
    public class PiratesController : Controller
    {
        // GET: Pirates
        public ActionResult Index()
        {
            return View();
        }
    }
}