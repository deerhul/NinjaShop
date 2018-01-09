using PirateShop.Models.Items;
using System.Collections.Generic;

namespace PirateShop.Models.ViewModels
{
    public class NinjaViewModel
    {
        //DOB to be implemented later
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Age { get; set; }
        public Clan clan { get; set; }
        public IEnumerable<Clan> Clans { get; set; }
        public Gender gender { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        //SECTION : "Building a Form with Bootstrap ep 4"

    }
}