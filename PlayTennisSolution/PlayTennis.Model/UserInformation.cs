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
        }
        public Guid Id { get; set; }

        public Guid WxuserId { get; set; }
        public virtual WxUser WxUser { get; set; }

        public Guid? UserBaseInfoId { get; set; }
        public virtual UserBaseInfo UserBaseInfo { get; set; }

        public Guid? ExercisePurposeId { get; set; }
        public virtual ExercisePurpose ExercisePurpose { get; set; }

        public Guid? SportsEquipmentId { get; set; }
        public SportsEquipment SportsEquipment { get; set; }

        public virtual ICollection<TennisCourt> TennisCourts { get; set; }
    }
}
