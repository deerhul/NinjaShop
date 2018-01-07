namespace PirateShop.Models.Ninja
{
    public class Clan
    {
        public int ClanID { get; set; }
        public string ClanName { get; set; }
        public int Members { get; set; }
        /*
         * not for later:
         * Might be better to not allow for the number of members to be set so easily.
         * make a method for incrementing and decrementing 'Members'.
         */
    }
}