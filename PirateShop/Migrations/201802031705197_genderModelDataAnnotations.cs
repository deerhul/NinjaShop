namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genderModelDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genders", "gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genders", "gender", c => c.String());
        }
    }
}
