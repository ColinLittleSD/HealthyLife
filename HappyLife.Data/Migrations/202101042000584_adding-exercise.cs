namespace HappyLife.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingexercise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Activity = c.String(nullable: false),
                        TimeSpentOnActivity = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercise", "PersonId", "dbo.Person");
            DropIndex("dbo.Exercise", new[] { "PersonId" });
            DropTable("dbo.Exercise");
        }
    }
}
