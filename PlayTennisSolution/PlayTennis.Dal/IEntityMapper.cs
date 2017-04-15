using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Dal
{
    public interface IEntityMapper
    {
        void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurationRegistrar);
    }
}
