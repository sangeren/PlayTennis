using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class PurposeCommunicationService : BaseService<PurposeCommunication, Guid>
    {
        public PurposeCommunicationService()
        {

        }

        public IList<PurposeCommunication> PurposeCommunications(Guid exerciseId)
        {
            var list = MyEntitiesRepository.Entities.Where(p => p.ExercisePurposeId.Equals(exerciseId)).ToList();
        }
    }
}
