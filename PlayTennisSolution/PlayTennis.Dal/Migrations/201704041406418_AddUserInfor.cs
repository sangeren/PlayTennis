namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInfor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInformation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExercisePurpose_Id = c.Guid(),
                        SportsEquipment_Id = c.Guid(),
                        UserBaseInfo_Id = c.Guid(),
                        WxUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExercisePurpose", t => t.ExercisePurpose_Id)
                .ForeignKey("dbo.SportsEquipment", t => t.SportsEquipment_Id)
                .ForeignKey("dbo.UserBaseInfo", t => t.UserBaseInfo_Id)
                .ForeignKey("dbo.WxUser", t => t.WxUser_Id)
                .Index(t => t.ExercisePurpose_Id)
                .Index(t => t.SportsEquipment_Id)
                .Index(t => t.UserBaseInfo_Id)
                .Index(t => t.WxUser_Id);
            
            CreateTable(
                "dbo.ExercisePurpose",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        IsCanChange = c.Boolean(nullable: false),
                        ExerciseExplain = c.String(),
                        Location_Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Speed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Accuracy = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TennisCourt", "UserInformation_Id", c => c.Guid());
            CreateIndex("dbo.TennisCourt", "UserInformation_Id");
            AddForeignKey("dbo.TennisCourt", "UserInformation_Id", "dbo.UserInformation", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInformation", "WxUser_Id", "dbo.WxUser");
            DropForeignKey("dbo.UserInformation", "UserBaseInfo_Id", "dbo.UserBaseInfo");
            DropForeignKey("dbo.TennisCourt", "UserInformation_Id", "dbo.UserInformation");
            DropForeignKey("dbo.UserInformation", "SportsEquipment_Id", "dbo.SportsEquipment");
            DropForeignKey("dbo.UserInformation", "ExercisePurpose_Id", "dbo.ExercisePurpose");
            DropIndex("dbo.UserInformation", new[] { "WxUser_Id" });
            DropIndex("dbo.UserInformation", new[] { "UserBaseInfo_Id" });
            DropIndex("dbo.UserInformation", new[] { "SportsEquipment_Id" });
            DropIndex("dbo.UserInformation", new[] { "ExercisePurpose_Id" });
            DropIndex("dbo.TennisCourt", new[] { "UserInformation_Id" });
            DropColumn("dbo.TennisCourt", "UserInformation_Id");
            DropTable("dbo.ExercisePurpose");
            DropTable("dbo.UserInformation");
        }
    }
}
