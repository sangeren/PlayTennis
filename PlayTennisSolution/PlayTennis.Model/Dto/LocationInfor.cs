using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    /// <summary>
    /// 位置信息
    /// </summary>
    public class LocationInfor
    {
        //{"country":"中国","country_code":0,"province":"北京市","city":"北京市","district":"海淀区"
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
