namespace DBInsertSpeedTests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestTypestoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsertTestType1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntProp = c.Int(nullable: false),
                        StringProp1 = c.String(),
                        StringProp2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsertTestType2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntProp = c.Int(nullable: false),
                        StringProp1 = c.String(),
                        StringProp2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsertTestType3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntProp = c.Int(nullable: false),
                        StringProp1 = c.String(),
                        StringProp2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InsertTestType3");
            DropTable("dbo.InsertTestType2");
            DropTable("dbo.InsertTestType1");
        }
    }
}
