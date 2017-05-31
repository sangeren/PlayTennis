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
            return list;
        }

        public void AddComment(Guid userBaseInfoId, Guid exercisePurposeId, string content)
        {

            if (string.IsNullOrEmpty(content))
            {
                return;
            }
            var comment = new PurposeCommunication()
            {
                UserBaseInfoId = userBaseInfoId,
                ExercisePurposeId = exercisePurposeId,
                Content = content
            };
            MyEntitiesRepository.Insert(comment);
        }
    }
}
