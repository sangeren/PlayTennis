using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class UserCentreDto
    {
        /// <summary>
        /// 是否 收到的预约
        /// </summary>
        public bool IsReceiveAppointment { get; set; }
        /// <summary>
        /// 是否 进行的预约
        /// </summary>
        public bool IsExerciseIng { get; set; }
        /// <summary>
        /// 是否 完成的预约
        /// </summary>
        public bool IsComplishExercise { get; set; }
    }
}
