namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttachmentFileNameColumnInAttachmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "AttachmentFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attachments", "AttachmentFileName");
        }
    }
}
