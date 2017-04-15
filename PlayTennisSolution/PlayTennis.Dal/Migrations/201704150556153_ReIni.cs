namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReIni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExercisePurpose",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        IsCanChange = c.Boolean(nullable: false),
                        ExerciseExplain = c.String(),
                        UserLocation_Latitude = c.Double(nullable: false),
                        UserLocation_Longitude = c.Double(nullable: false),
                        UserLocation_Speed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserLocation_Accuracy = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogHttpRequest",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Requst = c.String(),
                        Response = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogInformation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Level = c.Byte(nullable: false),
                        Message = c.String(),
                        Detaile = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SportsEquipment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TennisRacketCount = c.Int(),
                        TennisCount = c.Int(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TennisCourt",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourtName = c.String(),
                        CourtAddress = c.String(),
                        OpenTime = c.String(),
                        UserLocation_Latitude = c.Double(nullable: false),
                        UserLocation_Longitude = c.Double(nullable: false),
                        UserLocation_Speed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserLocation_Accuracy = c.String(),
                        UserInformationId = c.Guid(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInformation", t => t.UserInformationId)
                .Index(t => t.UserInformationId);
            
            CreateTable(
                "dbo.UserInformation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WxuserId = c.Guid(nullable: false),
                        UserBaseInfoId = c.Guid(),
                        ExercisePurposeId = c.Guid(),
                        SportsEquipmentId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExercisePurpose", t => t.ExercisePurposeId)
                .ForeignKey("dbo.SportsEquipment", t => t.SportsEquipmentId)
                .ForeignKey("dbo.UserBaseInfo", t => t.UserBaseInfoId)
                .ForeignKey("dbo.WxUser", t => t.WxuserId, cascadeDelete: true)
                .Index(t => t.WxuserId)
                .Index(t => t.UserBaseInfoId)
                .Index(t => t.ExercisePurposeId)
                .Index(t => t.SportsEquipmentId);
            
            CreateTable(
                "dbo.UserBaseInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NickName = c.String(),
                        AvatarUrl = c.String(),
                        Gender = c.Byte(nullable: false),
                        PlayAge = c.Double(nullable: false),
                        NowAddress = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Opneid = c.String(),
                        WxName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WxUserLogin",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Openid = c.String(),
                        SessionKey = c.String(),
                        LoginTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser");
            DropForeignKey("dbo.UserInformation", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.TennisCourt", "UserInformationId", "dbo.UserInformation");
            DropForeignKey("dbo.UserInformation", "SportsEquipmentId", "dbo.SportsEquipment");
            DropForeignKey("dbo.UserInformation", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropIndex("dbo.UserInformation", new[] { "SportsEquipmentId" });
            DropIndex("dbo.UserInformation", new[] { "ExercisePurposeId" });
            DropIndex("dbo.UserInformation", new[] { "UserBaseInfoId" });
            DropIndex("dbo.UserInformation", new[] { "WxuserId" });
            DropIndex("dbo.TennisCourt", new[] { "UserInformationId" });
            DropTable("dbo.WxUserLogin");
            DropTable("dbo.WxUser");
            DropTable("dbo.UserBaseInfo");
            DropTable("dbo.UserInformation");
            DropTable("dbo.TennisCourt");
            DropTable("dbo.SportsEquipment");
            DropTable("dbo.LogInformation");
            DropTable("dbo.LogHttpRequest");
            DropTable("dbo.ExercisePurpose");
        }
    }
}
