namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInStudentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "ApplicationUserId");
            AddForeignKey("dbo.Students", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "ApplicationUserId" });
            DropColumn("dbo.Students", "ApplicationUserId");
        }
    }
}
