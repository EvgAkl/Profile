namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnatationsToGroupsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Groups", "ImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "ImagePath", c => c.String());
            AlterColumn("dbo.Groups", "Name", c => c.Int(nullable: false));
        }
    }
}
