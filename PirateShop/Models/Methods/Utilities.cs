using PirateShop.Models.Items;
using PirateShop.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PirateShop.Models.Methods
{

    public class Utilities
    {
        private readonly ApplicationDbContext _context;

        public Utilities(ApplicationDbContext context)
        {
            this._context = context;
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

        public List<NinjaClanViewModel> CreateNinjaDisplay()
        {
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

                //shorter option.
                temp.clan = cList.Single(c => c.ClanID.Equals(item.clanID));
                temp.Gender = gList.Single(g => g.ID.Equals(item.genderID));

                //longer option but takes into account a scenario where clan and/or gender is unspecified
                //foreach (Clan c in cList)
                //{
                //    if (c.ClanID.Equals(item.clanID))
                //    {
                //        temp.clan = c;
                //    }
                //}
                //if (temp.clan == null)
                //{
                //    temp.clan = new Clan()
                //    {
                //        ClanID = 69,
                //        ClanName = countClan.ToString(),
                //        Members = 420
                //    };
                //}
                //foreach (Gender g in gList)
                //{
                //    if (g.ID.Equals(item.genderID))
                //    {
                //        temp.Gender = g;
                //    }
                //}
                //if (temp.Gender == null)
                //{
                //    temp.Gender = new Gender()
                //    {
                //        gender = countGender.ToString(),
                //        ID = 1234
                //    };
                //}

                NCV.Add(temp);
            }
            return NCV;
        }
    }
}