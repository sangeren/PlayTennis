using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class WxMessage : BaseEntity
    {
        /// <summary>
        /// id的类型：1，form；2，支付
        /// </summary>
        public byte MessageType { get; set; }
        /// <summary>
        /// 消息的key
        /// </summary>
        public Guid MessageKey { get; set; }
        /// <summary>
        /// id的值
        /// </summary>
        public string Vaule { get; set; }
        /// <summary>
        /// 是否使用：false 未；true 使用
        /// </summary>
        public bool IsUser { get; set; }
    }
}
