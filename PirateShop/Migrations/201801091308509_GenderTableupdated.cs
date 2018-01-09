namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderTableupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genders", "gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genders", "gender", c => c.Int(nullable: false));
        }
    }
}
