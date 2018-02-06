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
    }
}