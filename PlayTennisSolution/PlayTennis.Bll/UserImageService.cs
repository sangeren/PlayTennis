using PlayTennis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Bll
{
    public class UserImageService : BaseService<UserImage, Guid>
    {
        public void AddImage(Guid userInforId, string relativePath)
        {
            MyEntitiesRepository.Insert(new UserImage()
            {
                RelativePath = relativePath,
                IsDelete = false,
                UserInformationId = userInforId
            });
        }
    }
}
