namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changelocaltion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TennisCourt", "UserLocation_Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TennisCourt", "UserLocation_Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TennisCourt", "UserLocation_Speed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TennisCourt", "UserLocation_Accuracy", c => c.String());
            DropColumn("dbo.TennisCourt", "Location_Latitude");
            DropColumn("dbo.TennisCourt", "Location_Longitude");
            DropColumn("dbo.TennisCourt", "Location_Speed");
            DropColumn("dbo.TennisCourt", "Location_Accuracy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TennisCourt", "Location_Accuracy", c => c.String());
            AddColumn("dbo.TennisCourt", "Location_Speed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TennisCourt", "Location_Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TennisCourt", "Location_Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TennisCourt", "UserLocation_Accuracy");
            DropColumn("dbo.TennisCourt", "UserLocation_Speed");
            DropColumn("dbo.TennisCourt", "UserLocation_Longitude");
            DropColumn("dbo.TennisCourt", "UserLocation_Latitude");
        }
    }
}
