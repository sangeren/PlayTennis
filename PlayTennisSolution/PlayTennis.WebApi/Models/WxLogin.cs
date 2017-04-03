using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayTennis.WebApi.Models
{
    public class WxLogin
    {
        public string openid { get; set; }
        public string session_key { get; set; }
    }
}