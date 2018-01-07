namespace PirateShop.Models.Ninja
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class Ninja
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Clan clan { get; set; }
        public Gender gender { get; set; }
        public int Age { get; set; }
    }
}