using Microsoft.AspNet.Identity;
using PirateShop.Models;
using PirateShop.Models.Items;
using PirateShop.Models.Methods;
using PirateShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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
            /*
             * create list of NinjaClanViewModel
             * create same amount of NCV as Ninjas
             * get the clan that has the ID specified
             * get the gender that has the ID specified
             */

            List<NinjaClanViewModel> NCV = new List<NinjaClanViewModel>();
            List<Ninja> nList = _context.Ninjas.ToList();
            List<Clan> cList = _context.Clans.ToList();
            List<Gender> gList = _context.Genders.ToList();

            NinjaClanViewModel temp;

            foreach (var item in nList)
            {
                temp = new NinjaClanViewModel();
                temp.ninja = item;
                //temp.clan = _context.Clans.Single(c => c.ClanID.Equals(item.clanID));
                //temp.Gender = _context.Genders.Single(g => g.ID.Equals(item.genderID));
                foreach (Clan c in cList)
                {
                    if (c.ClanID.Equals(item.clanID))
                    {
                        temp.clan = c;
                    }
                }
                if (temp.clan == null)
                {
                    temp.clan = new Clan()
                    {
                        ClanID = 69,
                        ClanName = "Empty",
                        Members = 420
                    };
                }
                foreach (Gender g in gList)
                {
                    if (g.ID.Equals(item.genderID))
                    {
                        temp.Gender = g;
                    }
                }
                if (temp.Gender == null)
                {
                    temp.Gender = new Gender()
                    {
                        gender = "Null",
                        ID = 1234
                    };
                }

                NCV.Add(temp);
            }
            return View(NCV);

            //return View(new NinjaViewModel()
            //{
            //    Clans = clanList,
            //    Ninjas = ninjaList
            //});
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
                //Clan clan = _context.Clans.Single(c => c.ClanID == clanSelected);
                //Gender gender = _context.Genders.Single(g => g.ID == genderSelected);

                var ninja = new Ninja
                {
                    Name = viewModel.Name,
                    clanID = clanSelected,
                    genderID = genderSelected,
                    Age = viewModel.Age,
                    Creator = creator
                };

                _context.Ninjas.Add(ninja);
                _context.SaveChanges();

                //not currently working
                //string msg = string.Format("{0}, {1}, {2}, from the {3}",
                //    viewModel.Name,
                //    viewModel.Age,
                //    gender.gender,
                //    clan.ClanName);
                //viewModel = util.AlertMsg("Created Ninja...", msg);

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