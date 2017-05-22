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

        public Guid AppointmentId { get; set; }
        public Guid Id { get; set; }
        public string AvatarUrl { get; set; }
        public string AvatarUrl2 { get; set; }
        public string NickName { get; set; }
        public string NickName2 { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid ExercisePurposeId { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 性别:'男' 0, '女'1, '保密'2
        /// </summary>
        public byte Gender { get; set; }
        /// <summary>
        /// 球龄
        /// </summary>
        public double PlayAge { get; set; }
    }
}
