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
        }
        public Guid Id { get; set; }
        public UserBaseInfo UserBaseInfo { get; set; }
        public ExercisePurpose ExercisePurpose { get; set; }
        public SportsEquipment SportsEquipment { get; set; }
        public IList<TennisCourt> TennisCourts { get; set; }
    }
}
