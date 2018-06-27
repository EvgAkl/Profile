namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGroupEntity_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "DateOfChange", c => c.DateTime(nullable: false));
            DropColumn("dbo.Groups", "CreationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "CreationDate", c => c.String());
            DropColumn("dbo.Groups", "DateOfChange");
        }
    }
}
