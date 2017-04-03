using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class WxUserLogin
    {
        public Guid Id { get; set; }
        public string Openid { get; set; }
        public string SessionKey { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
