using Microsoft.AspNet.Identity;
using PirateShop.Models;
using PirateShop.Models.Items;
using PirateShop.Models.Methods;
using PirateShop.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PirateShop.Controllers
{
    public class NinjaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Utilities util;

        public NinjaController()
        {
            //Research application injection
            _context = new ApplicationDbContext();
            util = new Utilities(_context);
        }

        // GET: Pirate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NinjaDisplay()
        {


            var ninjaList = from item in _context.Ninjas
                select item;

            var clanList = from clanitem in _context.Clans
                select clanitem;



            return View(new NinjaViewModel()
            {
                Clans = clanList,
                Ninjas = ninjaList
            });
        }

        [Authorize]
        public ActionResult Create()
        {
            //AlertMsg("Created Ninja", "test");
            return View(util.makeModel(null));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(NinjaViewModel viewModel)
        {
            try
            {
                // the id of logged-in member
                var creatorId = User.Identity.GetUserId();
                var clanSelected = viewModel.Clan.ClanID;
                int genderSelected = viewModel.Gender.ID;

                var creator = _context.Users.Single(u => u.Id == creatorId);
                Clan clan = _context.Clans.Single(c => c.ClanID == clanSelected);
                Gender gender = _context.Genders.Single(g => g.ID == genderSelected);

                var ninja = new Ninja
                {
                    Name = viewModel.Name,
                    clan = clan,
                    gender = gender,
                    Age = viewModel.Age,
                    Creator = creator
                };

                _context.Ninjas.Add(ninja);
                _context.SaveChanges();

                string msg = string.Format("{0}, {1}, {2}, from the {3}",
                    viewModel.Name,
                    viewModel.Age,
                    gender.gender,
                    clan.ClanName);
                viewModel = util.AlertMsg("Created Ninja...", msg);

            }
            catch (Exception e)
            {
                viewModel = util.AlertMsg("Create ninja", "Failed");
            }

            //return RedirectToAction("Index", "Home");

            return View(viewModel);
        }
    }
}