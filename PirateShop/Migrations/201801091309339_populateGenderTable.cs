namespace PirateShop.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateGenderTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genders (gender) VALUES ('Male')");
            Sql("INSERT INTO Genders (gender) VALUES ('Female')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genders WHERE gender IN ('Male','Female')");
        }
    }
}
