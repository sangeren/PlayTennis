namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWxuuserid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserInformation", name: "WxUser_Id", newName: "WxuserId");
            RenameIndex(table: "dbo.UserInformation", name: "IX_WxUser_Id", newName: "IX_WxuserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserInformation", name: "IX_WxuserId", newName: "IX_WxUser_Id");
            RenameColumn(table: "dbo.UserInformation", name: "WxuserId", newName: "WxUser_Id");
        }
    }
}
