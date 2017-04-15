using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    /// <summary>
    /// 地理位置（默认是腾讯经纬度
    /// </summary>
    public class BaseLocation
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 速度，浮点数，单位m/s
        /// </summary>
        public decimal Speed { get; set; }
        /// <summary>
        /// 位置的精确度
        /// </summary>
        public string Accuracy { get; set; }
    }
}
