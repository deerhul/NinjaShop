using System.ComponentModel.DataAnnotations;

namespace PirateShop.Models.Items
{
    public class Clan
    {
        [Required]
        public int ClanID { get; set; }

        [Required]
        [StringLength(100)]
        public string ClanName { get; set; }

        [Required]
        public int Members { get; set; }
        /*
         * not for later:
         * Might be better to not allow for the number of members to be set so easily.
         * make a method for incrementing and decrementing 'Members'.
         */
    }
}