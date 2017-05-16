using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class WxUserLoginDto
    {
        public string Openid { get; set; }
        public string SessionKey { get; set; }
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
        public byte Gender { get; set; }
    }

    public class UserLoginDto
    {
        public Guid WxUserId  { get; set; }
        public Guid UserId  { get; set; }
        public Guid UserInforId  { get; set; }
    }
}
