using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Ninja
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class Ninja
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Clan clan { get; set; }

        [Required]
        public Gender gender { get; set; }

        [Required]
        public int Age { get; set; }
    }
}