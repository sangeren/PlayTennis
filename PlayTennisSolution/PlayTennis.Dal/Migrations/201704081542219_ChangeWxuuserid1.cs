namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWxuuserid1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser");
            DropIndex("dbo.UserInformation", new[] { "WxuserId" });
            AlterColumn("dbo.UserInformation", "WxuserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserInformation", "WxuserId");
            AddForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser");
            DropIndex("dbo.UserInformation", new[] { "WxuserId" });
            AlterColumn("dbo.UserInformation", "WxuserId", c => c.Guid());
            CreateIndex("dbo.UserInformation", "WxuserId");
            AddForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser", "Id");
        }
    }
}
