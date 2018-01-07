namespace PirateShop.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateClanTable : DbMigration
    {
        public override void Up()
        {
            //format: (int ClanID, string ClanName, int Members)
            Sql("INSERT INTO Clans (ClanName, Members) VALUES ('Hidden Leaf', 0)");
            Sql("INSERT INTO Clans (ClanName, Members) VALUES ('Hidden Sand', 0)");
            Sql("INSERT INTO Clans (ClanName, Members) VALUES ('Hidden Mist', 0)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Clans WHERE Members IN (0)");
        }
    }
}
