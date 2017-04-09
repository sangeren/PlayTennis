using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class WxUser
    {

        public Guid Id { get; set; }
        /// <summary>
        /// openid 微信唯一识别id
        /// </summary>
        public string Opneid { get; set; }
        /// <summary>
        /// 微信名称
        /// </summary>
        public string WxName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        //public virtual ICollection<UserInformation> UserInformations { get; set; }
    }
}
