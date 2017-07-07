namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RelativePath = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        UserInformationId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInformation", t => t.UserInformationId, cascadeDelete: true)
                .Index(t => t.UserInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImage", "UserInformationId", "dbo.UserInformation");
            DropIndex("dbo.UserImage", new[] { "UserInformationId" });
            DropTable("dbo.UserImage");
        }
    }
}
