using PirateShop.Models;
using PirateShop.Models.Items;
using PirateShop.Models.ViewModels;
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
            var vm = new NinjaViewModel
            {
                //Clan = new Clan(),
                //Gender = new Gender(),
                Clans = _context.Clans.ToList(),
                Genders = _context.Genders.ToList()
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(NinjaViewModel viewModel)
        {
            // the id of logged-in member
            //var creatorId = User.Identity.GetUserId();
            //var clanSelected = viewModel.clan;
            //var genderSelected = viewModel.gender;

            //var creator = _context.Users.Single(u => u.Id == creatorId);
            //var clan = _context.Clans.Find(clanSelected.ClanName);
            //var gender = _context.Genders.Single(g => g == genderSelected);

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

            AlertMsg("Name", viewModel.Name);
            AlertMsg("check", viewModel.Gender.ID.ToString());
            //return RedirectToAction("Index", "Home");

            viewModel = makeModel();

            return View(viewModel);
        }

        public void AlertMsg(string text, string text2)
        {

            string msg = string.Format("Content of {0}, is {1}.", text, text2);
            ViewData["AlertMsg"] = msg;
        }

        public NinjaViewModel makeModel()
        {
            List<SelectListItem> tempList
                = new List<SelectListItem>();

            tempList.Add(new SelectListItem() {Text = "Daryl", Value = "Beast"});
            tempList.Add(new SelectListItem() {Text = "Alchellle", Value = "Bitch"});
            tempList.Add(new SelectListItem() {Text = "Krystal", Value = "Teddybear Cate"});
            tempList.Add(new SelectListItem() {Text = "LuLu", Value = "Pisoshate"});
            tempList.Add(new SelectListItem() {Text = "Belle", Value = "Buldoggoloinks"});

            NinjaViewModel mm =
                new NinjaViewModel()
                {
                    Name = "",
                    Age = 0,
                    Clan = new Clan(),
                    Clans = _context.Clans.ToList(),
                    Gender = new Gender(),
                    Genders = _context.Genders.ToList(),
                    //clanList = clanListPopulator(),
                    genderList = genderListPopulator(),

                    nameList = new SelectList(tempList, "Value", "Text")
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
    }
}