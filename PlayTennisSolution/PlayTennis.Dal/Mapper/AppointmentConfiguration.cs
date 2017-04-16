using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;

namespace PlayTennis.Dal.Mapper
{
    public class AppointmentConfiguration : EntityTypeConfiguration<Appointment>, IEntityMapper
    {
        public AppointmentConfiguration()
        {
            this.HasRequired(p => p.Initiator).WithMany(p => p.InitiatorAppointments).HasForeignKey(p => p.InitiatorId).WillCascadeOnDelete(false);
            this.HasRequired(p => p.Invitee).WithMany(p => p.InviteeAppointments).HasForeignKey(p => p.InviteeId).WillCascadeOnDelete(false);
        }
        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }
    }
}
