using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class UserBaseInfo : BaseEntity
    {

        public string NickName { get; set; }
        public byte Gender { get; set; }
        public double PlayAge { get; set; }
        public string NowAddress { get; set; }
    }
}
