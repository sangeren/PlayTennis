namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageChangeMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserImage", "UserInformationId", "dbo.UserInformation");
            DropIndex("dbo.UserImage", new[] { "UserInformationId" });
            AlterColumn("dbo.UserImage", "UserInformationId", c => c.Guid());
            CreateIndex("dbo.UserImage", "UserInformationId");
            AddForeignKey("dbo.UserImage", "UserInformationId", "dbo.UserInformation", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImage", "UserInformationId", "dbo.UserInformation");
            DropIndex("dbo.UserImage", new[] { "UserInformationId" });
            AlterColumn("dbo.UserImage", "UserInformationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserImage", "UserInformationId");
            AddForeignKey("dbo.UserImage", "UserInformationId", "dbo.UserInformation", "Id", cascadeDelete: true);
        }
    }
}
