using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class LogInformation
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 异常级别：0 重要 紧急；1不重要 紧急；2重要 不紧急；3不重要 不紧急
        /// </summary>
        public Byte Level { get; set; }
        ///// <summary>
        ///// 请求
        ///// </summary>
        //public string Requst { get; set; }
        ///// <summary>
        ///// 响应
        ///// </summary>
        //public string Response { get; set; }
        /// <summary>
        /// 异常说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// exception 序列号
        /// </summary>
        public string Detaile { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }

    public class LogHttpRequest : BaseEntity
    {
        /// <summary>
        /// 请求
        /// </summary>
        public string Requst { get; set; }
        /// <summary>
        /// 响应
        /// </summary>
        public string Response { get; set; }
    }
}
