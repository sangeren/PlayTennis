using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.Dal.Mapper
{
    public class UserInformationDtoConfiguration : EntityTypeConfiguration<UserInformationDto>, IEntityMapper
    {
        public UserInformationDtoConfiguration()
        {
            //this.HasRequired(p => p.Initiator).WithMany(p => p.InitiatorAppointments).HasForeignKey(p => p.InitiatorId).WillCascadeOnDelete(false);
            this.Ignore(p => p.ExercisePurpose);
            this.Ignore(p => p.HasInitiatorAppointment);
        }
        public void RegistTo(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }
    }
}
