namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssignmentSubmissionModelRemodeling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentSubmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        StudentId = c.Int(nullable: false),
                        AttachmentId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        Grade = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignmentSubmissions", "StudentId", "dbo.Students");
            DropIndex("dbo.AssignmentSubmissions", new[] { "StudentId" });
            DropTable("dbo.AssignmentSubmissions");
        }
    }
}
