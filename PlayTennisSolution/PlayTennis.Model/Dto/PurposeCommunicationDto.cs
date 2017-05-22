using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model.Dto
{
    public class PurposeCommunicationDto
    {
        public UserInformation UserInformation { get; set; }
        public IList<PurposeCommunication> PurposeCommunications { get; set; }
    }
}
