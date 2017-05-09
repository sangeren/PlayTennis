namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMig : DbMigration
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
                        ExerciseState = c.Byte(nullable: false),
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
                        SportsEquipmentId = c.Guid(),
                        HasInitiatorAppointment = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ExercisePurpose_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SportsEquipment", t => t.SportsEquipmentId)
                .ForeignKey("dbo.UserBaseInfo", t => t.UserBaseInfoId)
                .ForeignKey("dbo.WxUser", t => t.WxuserId, cascadeDelete: true)
                .ForeignKey("dbo.ExercisePurpose", t => t.ExercisePurpose_Id)
                .Index(t => t.WxuserId)
                .Index(t => t.UserBaseInfoId)
                .Index(t => t.SportsEquipmentId)
                .Index(t => t.ExercisePurpose_Id);
            
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
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InitiatorId = c.Guid(nullable: false),
                        InviteeId = c.Guid(nullable: false),
                        ExercisePurposeId = c.Guid(nullable: false),
                        AppointmentState = c.Byte(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExercisePurpose", t => t.ExercisePurposeId, cascadeDelete: true)
                .ForeignKey("dbo.UserBaseInfo", t => t.InitiatorId)
                .ForeignKey("dbo.UserBaseInfo", t => t.InviteeId)
                .Index(t => t.InitiatorId)
                .Index(t => t.InviteeId)
                .Index(t => t.ExercisePurposeId);
            
            CreateTable(
                "dbo.AppointmentRecord",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AppointmentId = c.Guid(nullable: false),
                        UserBaseInfoId = c.Guid(nullable: false),
                        AppointmentState = c.Byte(nullable: false),
                        Remark = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointment", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.UserBaseInfo", t => t.UserBaseInfoId, cascadeDelete: true)
                .Index(t => t.AppointmentId)
                .Index(t => t.UserBaseInfoId);
            
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
                "dbo.PurposeCommunication",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserBaseInfoId = c.Guid(nullable: false),
                        ExercisePurposeId = c.Guid(nullable: false),
                        Content = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExercisePurpose", t => t.ExercisePurposeId, cascadeDelete: true)
                .ForeignKey("dbo.UserBaseInfo", t => t.UserBaseInfoId, cascadeDelete: true)
                .Index(t => t.UserBaseInfoId)
                .Index(t => t.ExercisePurposeId);
            
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
            DropForeignKey("dbo.PurposeCommunication", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.PurposeCommunication", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropForeignKey("dbo.UserInformation", "ExercisePurpose_Id", "dbo.ExercisePurpose");
            DropForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser");
            DropForeignKey("dbo.UserInformation", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "InviteeId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "InitiatorId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropForeignKey("dbo.AppointmentRecord", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.AppointmentRecord", "AppointmentId", "dbo.Appointment");
            DropForeignKey("dbo.TennisCourt", "UserInformationId", "dbo.UserInformation");
            DropForeignKey("dbo.UserInformation", "SportsEquipmentId", "dbo.SportsEquipment");
            DropForeignKey("dbo.ExercisePurpose", "UserInformationId", "dbo.UserInformation");
            DropIndex("dbo.PurposeCommunication", new[] { "ExercisePurposeId" });
            DropIndex("dbo.PurposeCommunication", new[] { "UserBaseInfoId" });
            DropIndex("dbo.AppointmentRecord", new[] { "UserBaseInfoId" });
            DropIndex("dbo.AppointmentRecord", new[] { "AppointmentId" });
            DropIndex("dbo.Appointment", new[] { "ExercisePurposeId" });
            DropIndex("dbo.Appointment", new[] { "InviteeId" });
            DropIndex("dbo.Appointment", new[] { "InitiatorId" });
            DropIndex("dbo.TennisCourt", new[] { "UserInformationId" });
            DropIndex("dbo.UserInformation", new[] { "ExercisePurpose_Id" });
            DropIndex("dbo.UserInformation", new[] { "SportsEquipmentId" });
            DropIndex("dbo.UserInformation", new[] { "UserBaseInfoId" });
            DropIndex("dbo.UserInformation", new[] { "WxuserId" });
            DropIndex("dbo.ExercisePurpose", new[] { "UserInformationId" });
            DropTable("dbo.WxUserLogin");
            DropTable("dbo.PurposeCommunication");
            DropTable("dbo.LogInformation");
            DropTable("dbo.LogHttpRequest");
            DropTable("dbo.WxUser");
            DropTable("dbo.AppointmentRecord");
            DropTable("dbo.Appointment");
            DropTable("dbo.UserBaseInfo");
            DropTable("dbo.TennisCourt");
            DropTable("dbo.SportsEquipment");
            DropTable("dbo.UserInformation");
            DropTable("dbo.ExercisePurpose");
        }
    }
}
