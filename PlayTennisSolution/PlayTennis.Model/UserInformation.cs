using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class UserInformation
    {
        public UserInformation()
        {
            Id = Guid.NewGuid();
            TennisCourts = new HashSet<TennisCourt>();
            ExercisePurposes = new HashSet<ExercisePurpose>();
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 微信用户id
        /// </summary>
        public Guid WxuserId { get; set; }
        /// <summary>
        /// 微信用户
        /// </summary>
        public virtual WxUser WxUser { get; set; }
        /// <summary>
        /// 用户基本信息id
        /// </summary>
        public Guid? UserBaseInfoId { get; set; }
        public virtual UserBaseInfo UserBaseInfo { get; set; }

        //public virtual ExercisePurpose ExercisePurpose { get; set; }
        /// <summary>
        /// 准备id
        /// </summary>
        public Guid? SportsEquipmentId { get; set; }
        public SportsEquipment SportsEquipment { get; set; }
        /// <summary>
        /// 球场
        /// </summary>
        public virtual ICollection<TennisCourt> TennisCourts { get; set; }
        /// <summary>
        /// 打球意向
        /// </summary>
        public virtual ICollection<ExercisePurpose> ExercisePurposes { get; set; }
    }
}
