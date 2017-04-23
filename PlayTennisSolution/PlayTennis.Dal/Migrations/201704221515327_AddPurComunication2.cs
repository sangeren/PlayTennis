namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurComunication2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurposeCommunication", "UserBaseInfoId", "dbo.UserBaseInfo");
            DropForeignKey("dbo.PurposeCommunication", "ExercisePurposeId", "dbo.ExercisePurpose");
            DropIndex("dbo.PurposeCommunication", new[] { "ExercisePurposeId" });
            DropIndex("dbo.PurposeCommunication", new[] { "UserBaseInfoId" });
            DropTable("dbo.PurposeCommunication");
        }
    }
}
