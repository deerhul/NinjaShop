using Microsoft.AspNet.Identity;
using PirateShop.Models;
using PirateShop.Models.Items;
using PirateShop.Models.ViewModels;
using System;
using System.Collections.Generic;
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
            //AlertMsg("Created Ninja", "test");
            return View(makeModel(null));
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
                viewModel = AlertMsg("Created Ninja...", msg);

            }
            catch (Exception e)
            {
                viewModel = AlertMsg("Create ninja", "Failed");
            }

            //return RedirectToAction("Index", "Home");

            return View(viewModel);
        }

        /* assigns a message to the NinjaViewModel attribute 
         * message displayed in view
        */
        public NinjaViewModel AlertMsg(string text, string text2)
        {

            string msg = string.Format("{0}. {1}.", text, text2);
            return makeModel(msg);

        }

        //responsible for populating a viewModel
        public NinjaViewModel makeModel(string message)
        {

            NinjaViewModel mm =
                new NinjaViewModel()
                {
                    Name = "",
                    Age = 0,
                    Clan = new Clan(),
                    Clans = _context.Clans.ToList(),
                    Gender = new Gender(),
                    Genders = _context.Genders.ToList(),
                    clanList = clanListPopulator(),
                    genderList = genderListPopulator(),
                    Message2View = message
                    //nameList = new SelectList(tempList, "Value", "Text")
                };



            return mm;
        }

        //create a list of SelectListItem of genders for the view
        public SelectList genderListPopulator()
        {
            SelectList output;
            var dblist = _context.Genders.ToList();
            List<SelectListItem> itemList = new List<SelectListItem>();

            foreach (var item in dblist)
            {
                itemList.Add(new SelectListItem()
                    {
                        Text = item.gender,
                        Value = item.ID.ToString()
                    }
                );
            }

            output = new SelectList(itemList, "Value", "Text");

            return output;
        }


        //create a list of SelectListItem of clans for the view
        public SelectList clanListPopulator()
        {
            SelectList output;
            var dblist = _context.Clans.ToList();
            List<SelectListItem> itemList = new List<SelectListItem>();

            foreach (var item in dblist)
            {
                itemList.Add(new SelectListItem()
                    {
                        Text = item.ClanName,
                        Value = item.ClanID.ToString()
                    }
                );
            }

            output = new SelectList(itemList, "Value", "Text");

            return output;
        }
    }
}