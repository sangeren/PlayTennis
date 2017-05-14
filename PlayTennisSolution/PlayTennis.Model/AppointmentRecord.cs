using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class AppointmentRecord : BaseEntity
    {
        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public Guid UserBaseInfoId { get; set; }
        public virtual UserBaseInfo UserBaseInfo { get; set; }
        /// <summary>
        /// -1：取消； 0:发起；1：接受；2 拒绝；3：完成；4：评论
        /// </summary>
        public byte AppointmentState { get; set; }
        /// <summary>
        /// 操作说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 微信表单id
        /// </summary>
        public string FormId { get; set; }
    }
}
