using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class UserImageDto
    {
        /// <summary>
        /// 全路径
        /// </summary>
        public string FullPath { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
