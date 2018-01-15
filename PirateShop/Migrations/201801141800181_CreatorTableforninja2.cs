namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatorTableforninja2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "Creator_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ninjas", "Creator_Id");
            AddForeignKey("dbo.Ninjas", "Creator_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Ninjas", "Creator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "Creator", c => c.String());
            DropForeignKey("dbo.Ninjas", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ninjas", new[] { "Creator_Id" });
            DropColumn("dbo.Ninjas", "Creator_Id");
        }
    }
}
