namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Log : DbMigration
    {
        public override void Up()
        {
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
            
            DropColumn("dbo.LogInformation", "Requst");
            DropColumn("dbo.LogInformation", "Response");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogInformation", "Response", c => c.String());
            AddColumn("dbo.LogInformation", "Requst", c => c.String());
            DropTable("dbo.LogHttpRequest");
        }
    }
}
