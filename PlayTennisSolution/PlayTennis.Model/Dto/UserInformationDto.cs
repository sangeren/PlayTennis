using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class UserInformationDto : UserInformation
    {
        public ExercisePurpose ExercisePurpose { get; set; }
        //public Appointment Appointment { get; set; }
        public bool HasInitiatorAppointment { get; set; }
    }
}
