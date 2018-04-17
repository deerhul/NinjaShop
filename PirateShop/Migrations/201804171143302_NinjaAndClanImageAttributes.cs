namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinjaAndClanImageAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "ClanLogo", c => c.String());
            AddColumn("dbo.Ninjas", "NinjaImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "NinjaImage");
            DropColumn("dbo.Clans", "ClanLogo");
        }
    }
}
