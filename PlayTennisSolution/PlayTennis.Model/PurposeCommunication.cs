using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class PurposeCommunication : BaseEntity
    {
        public Guid UserBaseInfoId { get; set; }
        public UserBaseInfo UserBaseInfo { get; set; }
        public Guid ExercisePurposeId { get; set; }
        public ExercisePurpose ExercisePurpose { get; set; }
        public string Content { get; set; }
    }
}
