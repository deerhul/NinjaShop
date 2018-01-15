namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatorTableforninja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "Creator");
        }
    }
}
