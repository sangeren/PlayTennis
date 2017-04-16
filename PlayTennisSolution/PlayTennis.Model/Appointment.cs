using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class Appointment : BaseEntity
    {
        public Appointment()
        {
            AppointmentRecords = new List<AppointmentRecord>();
        }
        public Guid InitiatorId { get; set; }
        /// <summary>
        /// 发起者
        /// </summary>
        public virtual UserBaseInfo Initiator { get; set; }
        public Guid InviteeId { get; set; }
        /// <summary>
        /// 受邀者
        /// </summary>
        public virtual  UserBaseInfo Invitee { get; set; }
        public Guid ExercisePurposeId { get; set; }
        /// <summary>
        /// 邀约
        /// </summary>
        public virtual ExercisePurpose ExercisePurpose{ get; set; }
        public virtual IList<AppointmentRecord> AppointmentRecords { get; set; }
    }
}
