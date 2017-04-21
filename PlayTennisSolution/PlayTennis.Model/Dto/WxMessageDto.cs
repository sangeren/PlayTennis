using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class WxTextMessageDto
    {
        /// <summary>
        /// OPENID
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// text
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public TextDto text { get; set; }

    }

    public class TextDto
    {
        public string content { get; set; }
    }
}
