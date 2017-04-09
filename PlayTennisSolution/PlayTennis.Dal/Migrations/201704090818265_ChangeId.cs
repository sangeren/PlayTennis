namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserInformation", name: "ExercisePurpose_Id", newName: "ExercisePurposeId");
            RenameColumn(table: "dbo.UserInformation", name: "SportsEquipment_Id", newName: "SportsEquipmentId");
            RenameColumn(table: "dbo.UserInformation", name: "UserBaseInfo_Id", newName: "UserBaseInfoId");
            RenameIndex(table: "dbo.UserInformation", name: "IX_UserBaseInfo_Id", newName: "IX_UserBaseInfoId");
            RenameIndex(table: "dbo.UserInformation", name: "IX_ExercisePurpose_Id", newName: "IX_ExercisePurposeId");
            RenameIndex(table: "dbo.UserInformation", name: "IX_SportsEquipment_Id", newName: "IX_SportsEquipmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserInformation", name: "IX_SportsEquipmentId", newName: "IX_SportsEquipment_Id");
            RenameIndex(table: "dbo.UserInformation", name: "IX_ExercisePurposeId", newName: "IX_ExercisePurpose_Id");
            RenameIndex(table: "dbo.UserInformation", name: "IX_UserBaseInfoId", newName: "IX_UserBaseInfo_Id");
            RenameColumn(table: "dbo.UserInformation", name: "UserBaseInfoId", newName: "UserBaseInfo_Id");
            RenameColumn(table: "dbo.UserInformation", name: "SportsEquipmentId", newName: "SportsEquipment_Id");
            RenameColumn(table: "dbo.UserInformation", name: "ExercisePurposeId", newName: "ExercisePurpose_Id");
        }
    }
}
