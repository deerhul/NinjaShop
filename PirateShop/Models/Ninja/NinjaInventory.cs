using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Ninja
{
    public class NinjaInventory
    {
        [Required]
        public int InventoryID { get; set; }

        public Ninja ninja;

        public List<Equipment> equipments { get; set; }
    }
}