namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurComunication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "AppointmentState", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "AppointmentState");
        }
    }
}
