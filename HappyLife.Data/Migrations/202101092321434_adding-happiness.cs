namespace HappyLife.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinghappiness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Happiness",
                c => new
                    {
                        HappinessId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        HappinessLevel = c.Int(nullable: false),
                        EmotionNotes = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HappinessId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Happiness", "PersonId", "dbo.Person");
            DropIndex("dbo.Happiness", new[] { "PersonId" });
            DropTable("dbo.Happiness");
        }
    }
}
