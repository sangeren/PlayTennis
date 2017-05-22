namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessageMig : DbMigration
    {
        public override void Up()
        {
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
            
            DropColumn("dbo.ExercisePurpose", "FormId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExercisePurpose", "FormId", c => c.String());
            DropTable("dbo.WxMessage");
        }
    }
}
