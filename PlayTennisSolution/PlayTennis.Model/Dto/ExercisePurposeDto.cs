using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class ExercisePurposeDto
    {
        public Guid WxUserId { get; set; }
        public string AvatarUrl { get; set; }
        public string NickName { get; set; }
        public double PlayAge { get; set; }        
        public byte Gender { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
        public double Disdance { get; set; }
        public string ExerciseExplain { get; set; }
    }
}
