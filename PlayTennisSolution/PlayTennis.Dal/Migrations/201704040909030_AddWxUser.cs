namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWxUser : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.LogInformation", "Level", c => c.Byte(nullable: false));
            AddColumn("dbo.LogInformation", "Requst", c => c.String());
            AddColumn("dbo.LogInformation", "Response", c => c.String());
            AddColumn("dbo.LogInformation", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogInformation", "CreateTime");
            DropColumn("dbo.LogInformation", "Response");
            DropColumn("dbo.LogInformation", "Requst");
            DropColumn("dbo.LogInformation", "Level");
            DropTable("dbo.WxUser");
        }
    }
}
