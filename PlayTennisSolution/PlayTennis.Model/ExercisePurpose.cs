using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class ExercisePurpose : BaseEntity
    {
        /// <summary>
        /// 运动开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 运动结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 时间是否可以协商
        /// </summary>
        public bool IsCanChange { get; set; }
        /// <summary>
        /// 运动意向说明
        /// </summary>
        public string ExerciseExplain { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public BaseLocation Location { get; set; }
    }
}
