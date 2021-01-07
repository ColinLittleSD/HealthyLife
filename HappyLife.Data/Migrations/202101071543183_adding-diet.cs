namespace HappyLife.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdiet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diet",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Breakfast = c.String(nullable: false),
                        Lunch = c.String(nullable: false),
                        Dinner = c.String(nullable: false),
                        Snacks = c.String(nullable: false),
                        Liquids = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diet", "PersonId", "dbo.Person");
            DropIndex("dbo.Diet", new[] { "PersonId" });
            DropTable("dbo.Diet");
        }
    }
}
