using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class AppointmentDto
    {
        /// <summary>
        /// 受邀人用户id
        /// </summary>
        public Guid inviteeId { get; set; }
        /// <summary>
        /// 意向id
        /// </summary>
        public Guid exercisePurposeId { get; set; }
        /// <summary>
        /// 预约id
        /// </summary>
        public Guid appointmentId { get; set; }
        /// <summary>
        /// 拒绝理由
        /// </summary>
        public string explain { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 操作类型|0：接受；1：拒绝；2：完成；3 评论
        /// </summary>
        public byte ActionType { get; set; }
    }
}
