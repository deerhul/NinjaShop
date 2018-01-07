using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Ninja
{
    public class Equipment
    {
        [Required]
        public int EquipmentID { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}