using PlayTennis.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Bll
{
    public class UserImageService : BaseService<UserImage, Guid>
    {
        public void AddImage(Guid userInforId, string relativePath)
        {
            if (MyEntitiesRepository.Entities.Count(p => p.UserInformationId == userInforId && p.IsDelete.Equals(false)) >= 9)
            {
                throw new Exception("最多保存9张图片！");
            }

            MyEntitiesRepository.Insert(new UserImage()
            {
                RelativePath = relativePath,
                IsDelete = false,
                UserInformationId = userInforId
            });
        }

        public void DeleteImage(Guid imageId)
        {
            var entity =
            MyEntitiesRepository.Entities.AsNoTracking().FirstOrDefault(p => p.Id == imageId && p.IsDelete.Equals(false));
            if (entity != null)
            {
                entity.IsDelete = true;
                entity.UpdateTime = DateTime.Now;
                MyEntitiesRepository.Update(entity);
            }
        }
    }
}
