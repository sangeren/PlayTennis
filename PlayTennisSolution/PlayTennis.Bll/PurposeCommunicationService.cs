using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.Bll
{
    public class PurposeCommunicationService : BaseService<PurposeCommunication, Guid>
    {
        public PurposeCommunicationService()
        {

        }

        public IList<ContentListDto> PurposeCommunications(Guid exerciseId)
        {
            var list = MyEntitiesRepository.Entities.Where(p => p.ExercisePurposeId.Equals(exerciseId))
                .Select(p => new ContentListDto()
                {
                    //AvatarUrl = p.UserBaseInfo.AvatarUrl,
                    Content = p.Content,
                    UserBaseInfoId = p.UserBaseInfoId
                })
                .ToList();
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
