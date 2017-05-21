using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class UserInformationDto : UserInformation
    {
        public ExercisePurpose ExercisePurpose { get; set; }
        //public Appointment Appointment { get; set; }
        /// <summary>
        /// 是否发起过预约
        /// </summary>
        public bool HasInitiatorAppointment { get; set; }
        ///// <summary>
        ///// 是否操作该预约请求
        ///// </summary>
        //public bool HasOperateAppointment { get; set; }
    }
}
