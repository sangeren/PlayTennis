using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class TennisCourtService : BaseService<TennisCourt, Guid>
    {
        public TennisCourtService()
        {
            UserInformationRepository = new GenericRepository<UserInformation>();
        }
        protected GenericRepository<UserInformation> UserInformationRepository { get; set; }

        public int AddTennisCourt(TennisCourt tennisCourt, WxUser wxUser)
        {
            var result = 0;
            if (tennisCourt == null || wxUser == null)
            {
                return result;
            }
            //var userInfor = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            var userInfor = UserInformationRepository.Entities.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));

            if (userInfor == null || userInfor.Id.Equals(Guid.Empty))
            {
                MyEntitiesRepository.UnitOfWork.EnableTransation = true;
                userInfor = new UserInformation()
                {
                    WxuserId = wxUser.Id
                };
                tennisCourt.UserInformationId = userInfor.Id;
                UserInformationRepository.Insert(userInfor);
                MyEntitiesRepository.Insert(tennisCourt);
                result = MyEntitiesRepository.UnitOfWork.SavaChanges();
            }
            else
            {
                tennisCourt.UserInformationId = userInfor.Id;
                result = MyEntitiesRepository.Insert(tennisCourt);
            }

            return result;
        }
    }
}
