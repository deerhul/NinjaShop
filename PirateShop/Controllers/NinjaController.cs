using PirateShop.Models;
using PirateShop.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PirateShop.Controllers
{
    public class NinjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NinjaController()
        {
            //Research application injection
            _context = new ApplicationDbContext();
        }
        // GET: Pirate
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            var vm = new NinjaViewModel
            {
                Clans = _context.Clans.ToList(),
                Genders = _context.Genders.ToList()
            };

            return View(vm);
        }
    }
}