using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class ContentDto
    {
        public Guid ExercisePurposeId { get; set; }
        public string Content { get; set; }
        public string FormId { get; set; }
    }
}
