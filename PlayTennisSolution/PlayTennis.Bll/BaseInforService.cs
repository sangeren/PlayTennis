using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class BaseInforService : BaseService<UserBaseInfo, Guid>
    {
        protected GenericRepository<WxUser> WxUserRepository { get; set; }
        protected GenericRepository<UserInformation> UserInformationRepository { get; set; }

        public int AddBaseInfor(UserBaseInfo baseInfo, WxUser wxUser)
        {
            var result = 0;
            if (baseInfo == null || wxUser == null)
            {
                return result;
            }
            //var userInfor = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            var userInfor = UserInformationRepository.Entities.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            if (userInfor != null && userInfor.UserBaseInfoId != null)
            {
                return result;
            }

            MyEntitiesRepository.UnitOfWork.EnableTransation = true;
            MyEntitiesRepository.Insert(baseInfo);
            if (userInfor == null)
            {
                userInfor = new UserInformation()
                {
                    UserBaseInfo = baseInfo,
                    WxuserId = wxUser.Id
                };
                UserInformationRepository.Insert(userInfor);
            }
            else
            {
                userInfor.UserBaseInfoId = baseInfo.Id;
                UserInformationRepository.Update(userInfor);
            }

            result = MyEntitiesRepository.UnitOfWork.SavaChanges();

            return result;
        }
    }
}
