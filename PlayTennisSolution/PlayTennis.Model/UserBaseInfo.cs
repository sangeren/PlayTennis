using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class UserBaseInfo : BaseEntity
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别:'男' 0, '女'1, '保密'2
        /// </summary>
        public byte Gender { get; set; }
        /// <summary>
        /// 球龄
        /// </summary>
        public double PlayAge { get; set; }
        /// <summary>
        /// 现居地址
        /// </summary>
        public string NowAddress { get; set; }
    }
}
