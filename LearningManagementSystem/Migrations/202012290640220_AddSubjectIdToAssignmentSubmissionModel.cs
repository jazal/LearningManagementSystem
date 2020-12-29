namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectIdToAssignmentSubmissionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentSubmissions", "SubjectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentSubmissions", "SubjectId");
        }
    }
}
