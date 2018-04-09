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

            //List<NinjaClanViewModel> NCV = new List<NinjaClanViewModel>();

            //var ninjaList = from item in _context.Ninjas
            //    select item;

            //var clanList = from clanitem in _context.Clans
            //    select clanitem;


            //foreach (var n in ninjaList)
            //{
            //    NCV.Add(new NinjaClanViewModel(){ninja = n, clan = new Clan()});
            //}

            //for (int i = 0 ; i < NCV.Count; i++)
            //{
            //    var temp = from item in clanList
            //        where item.ClanID == NCV[i].ninja.clan.ClanID
            //        select item;
            //    NCV[i].clan = (Clan)temp;
            //}

            List<Ninja> NCV = new List<Ninja>();
            NCV = _context.Ninjas.ToList();
            foreach (var item in NCV)
            {
                //item.gender = _context.Genders.Single(g => g.ID == item.gender.ID);
                //item.clan = _context.Clans.Single(c => c.ClanID == item.clan.ClanID);

                if (item.clan == null && item.gender == null)
                {
                    item.clan = new Clan()
                    {
                        ClanID = 69,
                        ClanName = "Clan field is empty",
                        Members = 420
                    };

                    item.gender = new Gender()
                    {
                        gender = "Gender field is empty",
                        ID = 420
                    };
                }
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