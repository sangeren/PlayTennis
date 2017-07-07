using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class UserImage : BaseEntity
    {
        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativePath { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public Guid? UserInformationId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual UserInformation UserInformation { get; set; }
    }
}
