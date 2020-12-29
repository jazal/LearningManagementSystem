namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsubjectIdToEmployeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "SubjectId", c => c.Int());
            CreateIndex("dbo.Employees", "SubjectId");
            AddForeignKey("dbo.Employees", "SubjectId", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Employees", new[] { "SubjectId" });
            DropColumn("dbo.Employees", "SubjectId");
        }
    }
}
