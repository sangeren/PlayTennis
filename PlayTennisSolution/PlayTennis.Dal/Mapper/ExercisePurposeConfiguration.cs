using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;

namespace PlayTennis.Dal.Mapper
{
    public class ExercisePurposeConfiguration : EntityTypeConfiguration<ExercisePurpose>, IEntityMapper
    {
        public ExercisePurposeConfiguration()
        {
            //this.Property(p => p.UserLocation.Latitude).HasPrecision(18, 5);
            //this.Property(p => p.UserLocation.Longitude).HasPrecision(18, 5);
        }

        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);

        }
    }
}
