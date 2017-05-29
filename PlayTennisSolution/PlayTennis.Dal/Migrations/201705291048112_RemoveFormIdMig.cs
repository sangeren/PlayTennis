namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFormIdMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppointmentRecord", "FormId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointmentRecord", "FormId", c => c.String());
        }
    }
}
