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
            AlertMsg("Created Ninja", "test");
            return View(makeModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(NinjaViewModel viewModel)
        {
            try
            {
                // the id of logged-in member
                //var creatorId = User.Identity.GetUserId();
                //var clanSelected = viewModel.Clan.ClanID;
                //int genderSelected = viewModel.Gender.ID;

                //var creator = _context.Users.Single(u => u.Id == creatorId);
                //Clan clan = _context.Clans.Single(c => c.ClanID == clanSelected);
                //Gender gender = _context.Genders.Single(g => g.ID == genderSelected);

                //var ninja = new Ninja
                //{
                //    Name = viewModel.Name,
                //    clan = clan,
                //    gender = gender,
                //    Age = viewModel.Age,
                //    Creator = creator
                //};

                //_context.Ninjas.Add(ninja);
                //_context.SaveChanges();

                //current not getting the values for Clan and Gender selected.
                //implement an alert box to check if the selected items actually has value

                //AlertMsg("Created Ninja",
                //    string.Format("{0}\n{1}\n{2}\n",
                //    viewModel.Name,
                //    viewModel.Age,
                //    viewModel.Gender.ID
                //    ));
                AlertMsg("Create ninja", "Success");
            }
            catch (Exception e)
            {
                AlertMsg("Create ninja", "Failed");
            }
            
            return RedirectToAction("Index", "Home");

            //viewModel = makeModel();

            //return View(viewModel);
        }

        //pop up message for testing or whatever
        public void AlertMsg(string text, string text2)
        {

            string msg = string.Format("{0}:\n---------\n {1}.", text, text2);
            ViewBag.alertMessage = msg;
        }

        public NinjaViewModel makeModel()
        {
            /*just for testing dropdownlist*/
            //List<SelectListItem> tempList
            //    = new List<SelectListItem>();

            //tempList.Add(new SelectListItem() {Text = "Daryl", Value = "Beast"});
            //tempList.Add(new SelectListItem() {Text = "Alchellle", Value = "Bitch"});
            //tempList.Add(new SelectListItem() {Text = "Krystal", Value = "Teddybear Cate"});
            //tempList.Add(new SelectListItem() {Text = "LuLu", Value = "Pisoshate"});
            //tempList.Add(new SelectListItem() {Text = "Belle", Value = "Buldoggoloinks"});

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

                    //nameList = new SelectList(tempList, "Value", "Text")
                };



            return mm;
        }

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