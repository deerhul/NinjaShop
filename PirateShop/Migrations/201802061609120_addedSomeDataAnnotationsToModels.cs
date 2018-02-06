namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSomeDataAnnotationsToModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ninjas", "clan_ClanID", "dbo.Clans");
            DropIndex("dbo.Ninjas", new[] { "clan_ClanID" });
            AlterColumn("dbo.NinjaInventories", "ninja", c => c.String(nullable: false));
            AlterColumn("dbo.Ninjas", "clan_ClanID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ninjas", "clan_ClanID");
            AddForeignKey("dbo.Ninjas", "clan_ClanID", "dbo.Clans", "ClanID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ninjas", "clan_ClanID", "dbo.Clans");
            DropIndex("dbo.Ninjas", new[] { "clan_ClanID" });
            AlterColumn("dbo.Ninjas", "clan_ClanID", c => c.Int());
            AlterColumn("dbo.NinjaInventories", "ninja", c => c.String());
            CreateIndex("dbo.Ninjas", "clan_ClanID");
            AddForeignKey("dbo.Ninjas", "clan_ClanID", "dbo.Clans", "ClanID");
        }
    }
}
