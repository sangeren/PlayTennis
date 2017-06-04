using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class ExercisePurposeIngDto
    {
        public ExercisePurposeIngDto()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public ExercisePurpose ExercisePurpose { get; set; }
        public UserBaseInfo InInitiator { get; set; }
        public UserBaseInfo Invitee { get; set; }
        public bool IsPastDate { get; set; }
        public IList<ContentListDto> Communications { get; set; }
    }
}
