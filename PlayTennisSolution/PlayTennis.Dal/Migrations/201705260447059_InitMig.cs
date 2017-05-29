namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInformation", "ExercisePurpose_Id", "dbo.ExercisePurposeA");
            DropIndex("dbo.UserInformation", new[] { "ExercisePurpose_Id" });
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
                        FormId = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointment", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.UserBaseInfo", t => t.UserBaseInfoId, cascadeDelete: true)
                .Index(t => t.AppointmentId)
                .Index(t => t.UserBaseInfoId);
            
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
                "dbo.WxMessage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MessageType = c.Byte(nullable: false),
                        MessageKey = c.Guid(nullable: false),
                        Vaule = c.String(),
                        IsUser = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
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
            
            AddColumn("dbo.UserInformation", "WxuserId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserInformation", "UserBaseInfoId", c => c.Guid());
            AddColumn("dbo.UserInformation", "SportsEquipmentId", c => c.Guid());
            CreateIndex("dbo.UserInformation", "WxuserId");
            CreateIndex("dbo.UserInformation", "UserBaseInfoId");
            CreateIndex("dbo.UserInformation", "SportsEquipmentId");
            AddForeignKey("dbo.UserInformation", "SportsEquipmentId", "dbo.SportsEquipment", "Id");
            AddForeignKey("dbo.UserInformation", "UserBaseInfoId", "dbo.UserBaseInfo", "Id");
            AddForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser", "Id", cascadeDelete: true);
            DropColumn("dbo.UserInformation", "HasInitiatorAppointment");
            DropColumn("dbo.UserInformation", "ExercisePurpose_Id");
            DropTable("dbo.ExercisePurposeA");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExercisePurposeA",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserInformation", "ExercisePurpose_Id", c => c.Guid());
            AddColumn("dbo.UserInformation", "HasInitiatorAppointment", c => c.Boolean());
            DropForeignKey("dbo.PurposeCommunication", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.PurposeCommunication", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropForeignKey("dbo.Appointment", "InviteeId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "InitiatorId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropForeignKey("dbo.UserInformation", "WxuserId", "dbo.WxUser");
            DropForeignKey("dbo.UserInformation", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.TennisCourt", "UserInformationId", "dbo.UserInformation");
            DropForeignKey("dbo.UserInformation", "SportsEquipmentId", "dbo.SportsEquipment");
            DropForeignKey("dbo.ExercisePurpose", "UserInformationId", "dbo.UserInformation");
            DropForeignKey("dbo.AppointmentRecord", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.AppointmentRecord", "AppointmentId", "dbo.Appointment");
            DropIndex("dbo.PurposeCommunication", new[] { "ExercisePurposeId" });
            DropIndex("dbo.PurposeCommunication", new[] { "UserBaseInfoId" });
            DropIndex("dbo.TennisCourt", new[] { "UserInformationId" });
            DropIndex("dbo.UserInformation", new[] { "SportsEquipmentId" });
            DropIndex("dbo.UserInformation", new[] { "UserBaseInfoId" });
            DropIndex("dbo.UserInformation", new[] { "WxuserId" });
            DropIndex("dbo.ExercisePurpose", new[] { "UserInformationId" });
            DropIndex("dbo.AppointmentRecord", new[] { "UserBaseInfoId" });
            DropIndex("dbo.AppointmentRecord", new[] { "AppointmentId" });
            DropIndex("dbo.Appointment", new[] { "ExercisePurposeId" });
            DropIndex("dbo.Appointment", new[] { "InviteeId" });
            DropIndex("dbo.Appointment", new[] { "InitiatorId" });
            DropColumn("dbo.UserInformation", "SportsEquipmentId");
            DropColumn("dbo.UserInformation", "UserBaseInfoId");
            DropColumn("dbo.UserInformation", "WxuserId");
            DropTable("dbo.WxUserLogin");
            DropTable("dbo.WxMessage");
            DropTable("dbo.PurposeCommunication");
            DropTable("dbo.LogInformation");
            DropTable("dbo.LogHttpRequest");
            DropTable("dbo.WxUser");
            DropTable("dbo.TennisCourt");
            DropTable("dbo.SportsEquipment");
            DropTable("dbo.ExercisePurpose");
            DropTable("dbo.UserBaseInfo");
            DropTable("dbo.AppointmentRecord");
            DropTable("dbo.Appointment");
            CreateIndex("dbo.UserInformation", "ExercisePurpose_Id");
            AddForeignKey("dbo.UserInformation", "ExercisePurpose_Id", "dbo.ExercisePurposeA", "Id");
        }
    }
}
