namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataAnatationFromImagePathProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "ImagePath", c => c.String(nullable: false));
        }
    }
}
