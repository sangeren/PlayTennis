namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModel : DbMigration
    {
        public override void Up()
        {
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
                        Location_Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Speed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Accuracy = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBaseInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NickName = c.String(),
                        Gender = c.Byte(nullable: false),
                        PlayAge = c.Double(nullable: false),
                        NowAddress = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserBaseInfo");
            DropTable("dbo.TennisCourt");
            DropTable("dbo.SportsEquipment");
        }
    }
}
