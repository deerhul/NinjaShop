using PirateShop.Models;
using PirateShop.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PirateShop.Controllers
{
    public class PirateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PirateController()
        {
            //Research application injection
            _context = new ApplicationDbContext();
        }
        // GET: Pirate
        public ActionResult Index()
        {
            return View();
        }

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