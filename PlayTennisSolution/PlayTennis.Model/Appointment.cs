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
        /// <summary>
        /// 发起人id
        /// </summary>
        public Guid InitiatorId { get; set; }
        /// <summary>
        /// 发起者
        /// </summary>
        public virtual UserBaseInfo Initiator { get; set; }
        /// <summary>
        /// 受邀者id
        /// </summary>
        public Guid InviteeId { get; set; }
        /// <summary>
        /// 受邀者
        /// </summary>
        public virtual UserBaseInfo Invitee { get; set; }
        /// <summary>
        /// 意向id
        /// </summary>
        public Guid ExercisePurposeId { get; set; }
        /// <summary>
        /// 邀约
        /// </summary>
        public virtual ExercisePurpose ExercisePurpose { get; set; }
        public virtual IList<AppointmentRecord> AppointmentRecords { get; set; }
        /// <summary>
        /// -1：取消； 0:发起；1：接受；2 拒绝；3：完成；4：评论
        /// </summary>
        public byte AppointmentState { get; set; }
    }
}
