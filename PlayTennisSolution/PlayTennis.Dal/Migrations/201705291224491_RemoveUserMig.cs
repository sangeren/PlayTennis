namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WxMessage", "BaseUserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WxMessage", "BaseUserId");
        }
    }
}
