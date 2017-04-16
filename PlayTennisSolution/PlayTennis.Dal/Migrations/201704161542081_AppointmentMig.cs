namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InitiatorId = c.Guid(nullable: false),
                        InviteeId = c.Guid(nullable: false),
                        ExercisePurposeId = c.Guid(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "InviteeId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "InitiatorId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.Appointment", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropForeignKey("dbo.AppointmentRecord", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.AppointmentRecord", "AppointmentId", "dbo.Appointment");
            DropIndex("dbo.AppointmentRecord", new[] { "UserBaseInfoId" });
            DropIndex("dbo.AppointmentRecord", new[] { "AppointmentId" });
            DropIndex("dbo.Appointment", new[] { "ExercisePurposeId" });
            DropIndex("dbo.Appointment", new[] { "InviteeId" });
            DropIndex("dbo.Appointment", new[] { "InitiatorId" });
            DropTable("dbo.AppointmentRecord");
            DropTable("dbo.Appointment");
        }
    }
}
