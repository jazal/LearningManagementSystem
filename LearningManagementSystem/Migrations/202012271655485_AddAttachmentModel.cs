namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttachmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        AttachmentType = c.Byte(nullable: false),
                        DueDate = c.DateTime(),
                        SubjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Attachments", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Attachments", new[] { "EmployeeId" });
            DropIndex("dbo.Attachments", new[] { "SubjectId" });
            DropTable("dbo.Attachments");
        }
    }
}
