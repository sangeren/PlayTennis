namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFormIdMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WxMessage", "BaseUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WxMessage", "BaseUserId", c => c.Guid(nullable: false));
        }
    }
}
