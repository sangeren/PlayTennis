namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.WxUserLogin");
        }
    }
}
