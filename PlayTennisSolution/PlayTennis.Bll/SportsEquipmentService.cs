using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;
using PlayTennis.Dal;

namespace PlayTennis.Bll
{
    public class SportsEquipmentService : BaseService<SportsEquipment, Guid>
    {
        public SportsEquipmentService()
        {
            WxUserRepository = new GenericRepository<WxUser>();
            UserInformationRepository = new GenericRepository<UserInformation>();
        }
        protected GenericRepository<WxUser> WxUserRepository { get; set; }
        protected GenericRepository<UserInformation> UserInformationRepository { get; set; }
        public int AddSportsEquipment(SportsEquipment sportsEquipment, WxUser wxUser)
        {
            var result = 0;
            if (sportsEquipment == null || wxUser == null)
            {
                return result;
            }
            //var userInfor = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            var userInfor = UserInformationRepository.Entities.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            if (userInfor != null && userInfor.SportsEquipmentId != null)
            {
                return result;
            }

            MyEntitiesRepository.UnitOfWork.EnableTransation = true;
            MyEntitiesRepository.Insert(sportsEquipment);
            if (userInfor == null)
            {
                userInfor = new UserInformation()
                {
                    SportsEquipment = sportsEquipment,
                    WxuserId = wxUser.Id
                };
                UserInformationRepository.Insert(userInfor);
            }
            else
            {
                userInfor.SportsEquipmentId = sportsEquipment.Id;
                UserInformationRepository.Update(userInfor);
            }

            result = MyEntitiesRepository.UnitOfWork.SavaChanges();
            return result;
        }
    }
}
