using System.Collections.Generic;

namespace PirateShop.Models.Ninja
{
    public class NinjaInventory
    {
        public int InventoryID { get; set; }
        public Ninja ninja;
        public List<Equipment> equipments { get; set; }
    }
}