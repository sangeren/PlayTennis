namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTennisCourt : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TennisCourt", name: "UserInformation_Id", newName: "UserInformationId");
            RenameIndex(table: "dbo.TennisCourt", name: "IX_UserInformation_Id", newName: "IX_UserInformationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TennisCourt", name: "IX_UserInformationId", newName: "IX_UserInformation_Id");
            RenameColumn(table: "dbo.TennisCourt", name: "UserInformationId", newName: "UserInformation_Id");
        }
    }
}
