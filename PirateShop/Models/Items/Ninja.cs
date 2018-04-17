using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Items
{
    public class Ninja
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Clan")]
        public int clanID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int genderID { get; set; }

        [Required]
        public int Age { get; set; }

        public ApplicationUser Creator { get; set; }

        [Display(Name = "Ninja Photo")]
        public string NinjaImage { get; set; }

        //to be implemented later
        //[Required]
        //public DateTime DOB { get; set; }
    }

    
}