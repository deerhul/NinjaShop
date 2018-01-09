namespace PirateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Ninjas", "gender_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ninjas", "gender_ID");
            AddForeignKey("dbo.Ninjas", "gender_ID", "dbo.Genders", "ID", cascadeDelete: true);
            DropColumn("dbo.Ninjas", "gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "gender", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ninjas", "gender_ID", "dbo.Genders");
            DropIndex("dbo.Ninjas", new[] { "gender_ID" });
            DropColumn("dbo.Ninjas", "gender_ID");
            DropTable("dbo.Genders");
        }
    }
}
