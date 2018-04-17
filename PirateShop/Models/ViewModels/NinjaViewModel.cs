using PirateShop.Models.Items;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PirateShop.Models.ViewModels
{
    public class NinjaViewModel
    {
        //DOB to be implemented later
        public string Name { get; set; }
        //public string Date { get; set; }
        //public string Time { get; set; }
        public int Age { get; set; }
        public Clan Clan { get; set; }
        public IEnumerable<Ninja> Ninjas { get; set; }
        public IEnumerable<Clan> Clans { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<Gender> Genders { get; set; }

        public SelectList nameList { get; set; }

        public SelectList genderList { get; set; }

        public SelectList clanList { get; set; }

        public string Message2View { get; set; }

        public string ImgURL { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        //SECTION : "Building a Form with Bootstrap ep 4"

    }
}