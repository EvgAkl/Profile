namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGroupEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "ImageFileSystemPath", c => c.String());
            AddColumn("dbo.Groups", "ImageProgectLinkPath", c => c.String());
            AlterColumn("dbo.Groups", "CreationDate", c => c.String());
            DropColumn("dbo.Groups", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "ImagePath", c => c.String());
            AlterColumn("dbo.Groups", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Groups", "ImageProgectLinkPath");
            DropColumn("dbo.Groups", "ImageFileSystemPath");
        }
    }
}
