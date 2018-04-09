namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes2NinjaClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ninjas", "clan_ClanID", "dbo.Clans");
            DropForeignKey("dbo.Ninjas", "gender_ID", "dbo.Genders");
            DropIndex("dbo.Ninjas", new[] { "clan_ClanID" });
            DropIndex("dbo.Ninjas", new[] { "gender_ID" });
            AddColumn("dbo.Ninjas", "clanID", c => c.Int(nullable: false));
            AddColumn("dbo.Ninjas", "genderID", c => c.Int(nullable: false));
            DropColumn("dbo.Ninjas", "clan_ClanID");
            DropColumn("dbo.Ninjas", "gender_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "gender_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Ninjas", "clan_ClanID", c => c.Int(nullable: false));
            DropColumn("dbo.Ninjas", "genderID");
            DropColumn("dbo.Ninjas", "clanID");
            CreateIndex("dbo.Ninjas", "gender_ID");
            CreateIndex("dbo.Ninjas", "clan_ClanID");
            AddForeignKey("dbo.Ninjas", "gender_ID", "dbo.Genders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Ninjas", "clan_ClanID", "dbo.Clans", "ClanID", cascadeDelete: true);
        }
    }
}
