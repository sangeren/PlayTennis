using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class AppointmentResultDto
    {
        //p.Invitee.AvatarUrl,p.Invitee.NickName,p.ExercisePurpose.StartTime,p.ExercisePurpose.EndTime
        public string AvatarUrl { get; set; }
        public string NickName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid ExercisePurposeId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
