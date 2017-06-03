using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayTennis.Dal;
using PlayTennis.Model;
using PlayTennis.Model.Dto;
using PlayTennis.Utility;

namespace PlayTennis.Bll
{
    public class UserInformationService : BaseService<PlayTennis.Model.UserInformation, Guid>
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected GenericRepository<AppointmentRecord> AppointmentRecordRepository { get; set; }
        protected GenericRepository<ExercisePurpose> ExercisePurposeRepository { get; set; }
        protected GenericRepository<Appointment> AppointmentRepository { get; set; }
        protected GenericRepository<UserBaseInfo> UserBaseInfoRepository { get; set; }

        public UserInformationService()
        {
            AppointmentRecordRepository = new GenericRepository<AppointmentRecord>();
            ExercisePurposeRepository = new GenericRepository<ExercisePurpose>();
            AppointmentRepository = new GenericRepository<Appointment>();
            UserBaseInfoRepository = new GenericRepository<UserBaseInfo>();
        }

        public UserCentreDto GetUserCentreDto(Guid userId)
        {
            //todo 进行预约有问题
            var result = new UserCentreDto();
            var exercisePurpose = ExercisePurposeRepository.Entities.FirstOrDefault(
                p => p.UserInformationId == userId && p.ExerciseState.Equals(0));
            var userInfo = MyEntitiesRepository.Entities.FirstOrDefault(p => p.Id.Equals(userId));

            if (exercisePurpose != null)
            {
                result.IsReceiveAppointment = AppointmentRepository.Entities.Any(
               p =>
                   p.InviteeId.Equals(userInfo.UserBaseInfoId.Value) && p.AppointmentState.Equals(0) &&
                   p.ExercisePurposeId.Equals(exercisePurpose.Id));
            }

            // any  && p.ExercisePurposeId.Equals(exercisePurpose.Id)
            result.IsExerciseIng = AppointmentRepository.Entities
                .Any(
                    p =>
                        (p.InviteeId.Equals(userInfo.UserBaseInfoId.Value) || p.InitiatorId.Equals(userInfo.UserBaseInfoId.Value)) && p.AppointmentState.Equals(1));
            result.IsComplishExercise = AppointmentRepository.Entities
                .Any(
                    p =>
                        (p.InviteeId.Equals(userInfo.UserBaseInfoId.Value) || p.InitiatorId.Equals(userId)) && p.AppointmentState.Equals(3));

            return result;
        }

        public UserInformationDto GetUserInformationById(Guid wxUserid)
        {
            var userInfo = MyEntitiesRepository.Entities
                //.Include(p => p.ExercisePurpose)
                .Include(p => p.UserBaseInfo)
                .Include(p => p.SportsEquipment)
                .Include(p => p.TennisCourts)
                .FirstOrDefault(p => p.WxuserId.Equals(wxUserid));
            if (userInfo == null)
            {
                return null;
            }

            var purpose =
                ExercisePurposeRepository.Entities.SingleOrDefault(
                    p => p.UserInformationId == userInfo.Id && p.ExerciseState == 0);
            var result = MapperHelper.MyMapper.Map<UserInformationDto>(userInfo);
            result.ExercisePurpose = purpose;

            //var jsonSetting = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            //_log.Info(JsonConvert.SerializeObject(result, jsonSetting));

            return result;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="initiatorId">发起人id</param>
        /// <returns></returns>
        public UserInformationDto GetUserInformationByuserInformationId(Guid userid, Guid initiatorId)
        {
            UserInformationDto userInforDto = null;
            var userInfo = MyEntitiesRepository.Entities
                //.Include(p => p.ExercisePurpose)
                .Include(p => p.UserBaseInfo)
                .Include(p => p.SportsEquipment)
                .Include(p => p.TennisCourts)
                .FirstOrDefault(p => p.UserBaseInfoId == (userid));
            if (userInfo == null)
            {
                return null;
            }

            var result = MapperHelper.MyMapper.Map<UserInformationDto>(userInfo);

            var purpose =
                 ExercisePurposeRepository.Entities.SingleOrDefault(
                     p => p.UserInformationId == userInfo.Id && p.ExerciseState == 0);
            result.ExercisePurpose = purpose;

            if (purpose != null)
            {
                result.HasInitiatorAppointment =
                    AppointmentRepository.Entities.Any(
                        p =>
                            p.ExercisePurposeId == purpose.Id && p.InitiatorId == initiatorId &&
                            (p.AppointmentState == 0 || p.AppointmentState == 1 || p.AppointmentState == 2));
                //result.HasOperateAppointment = AppointmentRepository.Entities.Any(
                //        p =>
                //            p.ExercisePurposeId == purpose.Id && p.InitiatorId == initiatorId &&
                //            (p.AppointmentState == 1 || p.AppointmentState == 2));
            }
            return result;

        }
    }
}
