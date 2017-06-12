using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
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
    public class ExercisePurposeService
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PalyTennisDb Context { private get; set; }

        public ExercisePurposeService()
        {
            Context = new PalyTennisDb();
        }

        //public IEnumerable<> 
        public ExercisePurpose GetPurposeById(Guid wxUserid)
        {
            ExercisePurpose purpose = null;
            var userInfor = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUserid));
            if (userInfor != null && userInfor.Id != Guid.Empty)//ExercisePurpose
            {
                purpose = Context.ExercisePurpose.SingleOrDefault(p => p.UserInformationId == userInfor.Id && p.ExerciseState == 0);
            }
            return purpose;
        }
        public ExercisePurpose GetPurposeByEntityId(Guid exercisePurposeId)
        {
            ExercisePurpose purpose = null;
            return Context.ExercisePurpose.FirstOrDefault(p => p.Id.Equals(exercisePurposeId));
        }

        public string GetFormIdByEntityId(Guid baseUserId, byte formIdType = 1)
        {
            var message = Context.WxMessage.FirstOrDefault(p => p.MessageKey.Equals(baseUserId) && p.MessageType.Equals(1) && p.IsUser.Equals(false));
            if (message != null && !string.IsNullOrEmpty(message.Vaule))
            {
                message.IsUser = true;
                message.UpdateTime = DateTime.Now;

                var count = Context.SaveChanges();
                if (count > 0)
                {
                    return message.Vaule;
                }
            }
            return null;
        }
        public int AddPurpose(EditPurposeDto purposeDto, WxUser wxUser)
        {
            _log.Info(JsonConvert.SerializeObject(purposeDto));

            var result = 0;
            if (purposeDto == null || wxUser == null)
            {
                return result;
            }
            var userInfor = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            if (userInfor == null || userInfor.Id.Equals(Guid.Empty))
            {
                return result;
            }

            var oldPurposeCount =
                Context.ExercisePurpose.Count(p => p.UserInformationId == userInfor.Id && p.ExerciseState == 0);
            if (oldPurposeCount > 0)
            {
                return result;
            }
            //if (userInfor != null && userInfor.ExercisePurposeId != null && userInfor.ExercisePurposeId != Guid.Empty)
            //{
            //    return result;
            //}

            if (purposeDto.userLocation.longitude < 0.01 || purposeDto.userLocation.latitude < 0.01)
            {
                return result;
            }

            //暂只开启 上海和深圳地址
            var userLocation =
                HttpHelper.GetLocationInfor(purposeDto.userLocation.longitude.ToString(CultureInfo.InvariantCulture),
                    purposeDto.userLocation.latitude.ToString(CultureInfo.InvariantCulture));

            _log.Info(JsonConvert.SerializeObject(userLocation));

            if (userLocation.Province.Equals("上海市") || (userLocation.Province.Equals("广东省") && userLocation.City.Equals("深圳市")))
            {

            }
            else
            {
                return result;
            }

            var purpose = new ExercisePurpose()
                {
                    EndTime = purposeDto.endTime,
                    ExerciseExplain = purposeDto.exerciseExplain,
                    IsCanChange = purposeDto.isCanChange,
                    UserLocation = new BaseLocation()
                    {
                        Accuracy = purposeDto.userLocation.accuracy,
                        Latitude = purposeDto.userLocation.latitude,
                        Longitude = purposeDto.userLocation.longitude,
                        Speed = purposeDto.userLocation.speed
                    },
                    StartTime = purposeDto.startTime,
                    UserInformationId = userInfor.Id,
                    ExerciseState = 0,
                    //FormId = purposeDto.formId
                };
            Context.ExercisePurpose.Add(purpose);

            if (userInfor.UserBaseInfoId != null)
                SaveWxFormId(userInfor.UserBaseInfoId.Value, purposeDto.formId);

            result = Context.SaveChanges();

            return result;
        }

        public void SaveWxFormId(Guid key, string formId, byte formType = 1)
        {
            var messageId = new WxMessage()
            {
                MessageType = formType,
                MessageKey = key,
                Vaule = formId,
                IsUser = false
            };
            Context.WxMessage.Add(messageId);
        }

        public int EditPurpose(EditPurposeDto purposeDto)
        {
            var result = 0;
            if (purposeDto == null || purposeDto.Id.Equals(Guid.Empty))
            {
                return result;
            }

            var hasAppointment =
                Context.Appointment.Any(
                    p => p.ExercisePurposeId.Equals(purposeDto.Id) && p.AppointmentState != -1);
            if (hasAppointment)
            {
                return result;
            }

            var purpose =
                Context.ExercisePurpose.Include(p => p.UserInformation).FirstOrDefault(p => p.Id == purposeDto.Id);
            if (purpose == null || purpose.Id != purposeDto.Id)
            {
                return result;
            }

            purpose.EndTime = purposeDto.endTime;
            purpose.ExerciseExplain = purposeDto.exerciseExplain;
            purpose.IsCanChange = purposeDto.isCanChange;
            purpose.UserLocation = new BaseLocation()
            {
                Accuracy = purposeDto.userLocation.accuracy,
                Latitude = purposeDto.userLocation.latitude,
                Longitude = purposeDto.userLocation.longitude,
                Speed = purposeDto.userLocation.speed
            };
            purpose.StartTime = purposeDto.startTime;
            purpose.UpdateTime = DateTime.Now;
            Context.ExercisePurpose.AddOrUpdate(purpose);

            if (purpose.UserInformation.UserBaseInfoId != null)
            {
                var messageId = new WxMessage()
                {
                    MessageType = 1,
                    MessageKey = purpose.UserInformation.UserBaseInfoId.Value,
                    Vaule = purposeDto.formId,
                    IsUser = false
                };
                Context.WxMessage.Add(messageId);
            }

            result = Context.SaveChanges();

            return result;
        }

        public List<ExercisePurposeDto> PurposeList(Guid wxUserId, int pageIndex, int pageSize, double latitude, double longitude, double disdance = 10)
        {
            //IQueryable<UserInformation> listOri = Context.UserInformation;
            IQueryable<ExercisePurpose> listOri = Context.ExercisePurpose;

            MapPoint[] ps = TencentMap.Range(new MapPoint(longitude, latitude), disdance, MapOption.Square);
            var minLng = ps[1].Lng;
            var maxLng = ps[3].Lng;
            var minLat = ps[2].Lat;
            var maxLat = ps[0].Lat;
            //listOri =
            //    listOri.Where(
            //        p =>
            //            p.ExercisePurposeId != null && p.ExercisePurpose.UserLocation.Longitude > minLng &&
            //            p.ExercisePurpose.UserLocation.Longitude < maxLng &&
            //            p.ExercisePurpose.UserLocation.Latitude > minLat &&
            //            p.ExercisePurpose.UserLocation.Latitude < maxLat);

            var list = listOri
                              .Where(p => p.EndTime.Value.CompareTo(DateTime.Now) >= 0 && !p.UserInformation.WxuserId.Equals(wxUserId))
                              .Select(p => new ExercisePurposeDto()
                              {
                                  Id = p.UserInformation.UserBaseInfo.Id,
                                  WxUserId = p.UserInformation.WxuserId,
                                  AvatarUrl = p.UserInformation.UserBaseInfo.AvatarUrl,
                                  NickName = p.UserInformation.UserBaseInfo.NickName,
                                  PlayAge = p.UserInformation.UserBaseInfo.PlayAge,
                                  Gender = p.UserInformation.UserBaseInfo.Gender,
                                  Latitude = p.UserLocation.Latitude,
                                  Longitude = p.UserLocation.Longitude,
                                  ExerciseExplain = p.ExerciseExplain
                              })
                              .ToList();

            if ((Math.Abs(latitude) > 0) && (Math.Abs(longitude) > 0))
            {
                foreach (var purposeDto in list)
                {
                    if (!(Math.Abs(purposeDto.Latitude) > 0) || !(Math.Abs(purposeDto.Longitude) > 0))
                    {
                        continue;
                    }
                    purposeDto.Disdance = TencentMap.GetDistance(longitude, purposeDto.Longitude, latitude, purposeDto.Latitude);
                }
            }

            var listDistansc0 = list.Where(p => p.Disdance < 0.01);

            list = list
                .Where(p => p.Disdance >= 0.01)
                .OrderBy(p => p.Disdance)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
            if (list.Count < pageSize)
            {
                list.AddRange(listDistansc0);
                list = list.Take(pageSize).ToList();
            }

            return list;
        }

        public List<ExercisePurposeDto> PurposeListFinish(Guid useInforId, int pageIndex, int pageSize)
        {
            var result = Context.ExercisePurpose.Where(p => p.UserInformationId == useInforId && p.ExerciseState.Equals(1))
                  .OrderByDescending(p => p.CreateTime)
                    .Skip((pageIndex - 1) * pageSize)
                  .Take(pageSize)
                   .Select(p => new ExercisePurposeDto()
                   {
                       Id = p.UserInformation.UserBaseInfo.Id,
                       WxUserId = p.UserInformation.WxuserId,
                       AvatarUrl = p.UserInformation.UserBaseInfo.AvatarUrl,
                       NickName = p.UserInformation.UserBaseInfo.NickName,
                       PlayAge = p.UserInformation.UserBaseInfo.PlayAge,
                       Gender = p.UserInformation.UserBaseInfo.Gender,
                       Latitude = p.UserLocation.Latitude,
                       Longitude = p.UserLocation.Longitude,
                       ExerciseExplain = p.ExerciseExplain
                   })
                  .ToList();

            return result;
        }

        public ExercisePurposeIngDto GetUserExercisePurpose(Guid userInforId, Guid exercisePurposeId)
        {
            ExercisePurposeIngDto result = null;
            var userInfor = Context.UserInformation.FirstOrDefault(p => p.Id.Equals(userInforId));
            var exercise = Context.ExercisePurpose.FirstOrDefault(p => p.Id == exercisePurposeId
                && p.ExerciseState == 0);

            if (userInfor != null && userInfor.UserBaseInfoId != null && exercise != null)
            {
                var appointment =
                  Context.Appointment.Include(p => p.Initiator)
                  .Include(p => p.Invitee)
                  .FirstOrDefault(
                      p => (p.InviteeId.Equals(userInfor.UserBaseInfoId.Value) || p.InitiatorId.Equals(userInfor.UserBaseInfoId.Value)) && p.ExercisePurposeId.Equals(exercise.Id) && p.AppointmentState == 1);
                if (appointment != null)
                {
                    result = new ExercisePurposeIngDto
                    {
                        ExercisePurpose = exercise,
                        InInitiator = appointment.Initiator,
                        Invitee = appointment.Invitee,
                        AppointmentId = appointment.Id
                    };
                    if (result.ExercisePurpose.EndTime != null)
                        result.IsPastDate = result.ExercisePurpose.EndTime.Value.CompareTo(DateTime.Now) <= 0;
                    //todo debug
                    //result.IsPastDate = true;
                }
            }
            //Context.Appointment.FirstOrDefault(p=>p.)

            return result;
        }
    }
}
