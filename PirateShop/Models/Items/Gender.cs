using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Items
{
    public class Gender
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
    }

}