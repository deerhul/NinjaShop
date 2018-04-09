using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PirateShop.Models.Items;

namespace PirateShop.Models.ViewModels
{
    public class NinjaClanViewModel
    {
        public Ninja ninja { get; set; }
        public Clan clan { get; set; }

        //public NinjaClanViewModel()
        //{
        //    ninja = new Ninja();
        //    clan = new Clan();
        //}
    }
}