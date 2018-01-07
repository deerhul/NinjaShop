using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Items
{
    public class NinjaInventory
    {
        [Key]
        [Required]
        public int InventoryID { get; set; }

        public string ninja { get; set; }

        public List<Equipment> equipments { get; set; }
    }
}