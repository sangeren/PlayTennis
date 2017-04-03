namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogInformation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Message = c.String(),
                        Detaile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogInformation");
        }
    }
}
