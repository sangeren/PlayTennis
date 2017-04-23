using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class UserInformationDto : UserInformation
    {
        public Appointment Appointment { get; set; }
    }
}
