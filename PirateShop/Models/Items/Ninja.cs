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
        public int clanID { get; set; }

        [Required]
        public int genderID { get; set; }

        [Required]
        public int Age { get; set; }

        public ApplicationUser Creator { get; set; }

        //to be implemented later
        //[Required]
        //public DateTime DOB { get; set; }
    }

    
}