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
        /// 0:创建成功；1：结束；2：删除
        /// </summary>
        public byte ExerciseState { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public BaseLocation UserLocation { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid? UserInformationId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual UserInformation UserInformation { get; set; }
        /// <summary>
        /// 微信表单id
        /// </summary>
        public string FormId { get; set; }
    }
}
