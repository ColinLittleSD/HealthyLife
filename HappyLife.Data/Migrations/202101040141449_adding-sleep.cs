namespace HappyLife.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsleep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sleep",
                c => new
                    {
                        SleepId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        HoursSlept = c.Int(nullable: false),
                        WakeUpTime = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SleepId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sleep", "PersonId", "dbo.Person");
            DropIndex("dbo.Sleep", new[] { "PersonId" });
            DropTable("dbo.Sleep");
        }
    }
}
