namespace PlayTennis.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFormidMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExercisePurpose", "FormId", c => c.String());
            AddColumn("dbo.AppointmentRecord", "FormId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppointmentRecord", "FormId");
            DropColumn("dbo.ExercisePurpose", "FormId");
        }
    }
}
