using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class TennisCourt : BaseEntity
    {
        public string CourtName { get; set; }
        public string CourtAddress { get; set; }
        public string OpenTime { get; set; }
        public BaseLocation UserLocation { get; set; }
        public virtual UserInformation UserInformation { get; set; }
    }
}
