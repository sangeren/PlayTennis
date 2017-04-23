using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.Bll
{
    public class UserInformationService : BaseService<PlayTennis.Model.UserInformation, Guid>
    {
        protected GenericRepository<AppointmentRecord> AppointmentRecordRepository { get; set; }

        public UserInformationService()
        {
            AppointmentRecordRepository = new GenericRepository<AppointmentRecord>();
        }

        public UserInformation GetUserInformationById(Guid wxUserid)
        {
            return MyEntitiesRepository.Entities
                .Include(p => p.ExercisePurpose)
                .Include(p => p.UserBaseInfo)
                .Include(p => p.SportsEquipment)
                .Include(p => p.TennisCourts)
                .FirstOrDefault(p => p.WxuserId.Equals(wxUserid));
        }
        public UserInformation GetUserInformationByuserInformationId(Guid userid, Guid initiatorId)
        {
            UserInformationDto userInforDto = null;
            var userInfo = MyEntitiesRepository.Entities
                .Include(p => p.ExercisePurpose)
                .Include(p => p.UserBaseInfo)
                .Include(p => p.SportsEquipment)
                .Include(p => p.TennisCourts)
                .FirstOrDefault(p => p.Id.Equals(userid));
            return userInfo;
            if (userInfo!=null)
            {
                //var resp = WebApiApplication.MyMapper.Map<UserInformationDto>(response);
                
            }

            var appointment =
                AppointmentRecordRepository
                    .Entities
                    .FirstOrDefault(p => p.Appointment.AppointmentState == 0
                                         &&
                                         p.Appointment.InitiatorId.Equals(initiatorId)
                                         &&
                                         p.Appointment.ExercisePurposeId.Equals(userInfo.ExercisePurposeId.Value));

        }
    }
}
