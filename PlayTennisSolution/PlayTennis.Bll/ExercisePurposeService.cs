using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;
using PlayTennis.Model.Dto;
using PlayTennis.Utility;

namespace PlayTennis.Bll
{
    public class ExercisePurposeService
    {
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
            if (userInfor != null && userInfor.Id != Guid.Empty && userInfor.ExercisePurposeId != null)
            {
                purpose = Context.ExercisePurpose.FirstOrDefault(p => p.Id == userInfor.ExercisePurposeId.Value);
            }
            return purpose;
        }
        public int AddPurpose(EditPurposeDto purposeDto, WxUser wxUser)
        {
            var result = 0;
            if (purposeDto == null || wxUser == null)
            {
                return result;
            }
            var userInfor = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            if (userInfor != null && userInfor.ExercisePurposeId != null && userInfor.ExercisePurposeId != Guid.Empty)
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
                    StartTime = purposeDto.startTime
                };
            Context.ExercisePurpose.Add(purpose);

            //var userInfo = Context.UserInformation.FirstOrDefault(p => p.WxuserId.Equals(wxUser.Id));
            //if (userInfo != null && userInfo.Id.Equals(Guid.Empty))
            if (userInfor == null)
            {
                userInfor = new UserInformation()
                {
                    ExercisePurpose = purpose,
                    WxuserId = wxUser.Id
                };
                Context.UserInformation.Add(userInfor);
            }
            else
            {
                userInfor.ExercisePurpose = purpose;
            }

            result = Context.SaveChanges();

            return result;
        }
        public int EditPurpose(EditPurposeDto purposeDto)
        {
            var result = 0;
            if (purposeDto == null || purposeDto.Id.Equals(Guid.Empty))
            {
                return result;
            }
            var purpose = Context.ExercisePurpose.FirstOrDefault(p => p.Id == purposeDto.Id);
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
            result = Context.SaveChanges();

            return result;
        }

        public List<ExercisePurposeDto> PurposeList(Guid wxUserId, int pageIndex, int pageSize, double latitude, double longitude, double disdance = 10)
        {
            IQueryable<UserInformation> listOri = Context.UserInformation;
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
                              .Where(p => p.UserBaseInfoId != null && p.ExercisePurpose.StartTime.Value.CompareTo(DateTime.Now) >= 0)
                              .Select(p => new ExercisePurposeDto()
                              {
                                  Id = p.UserBaseInfo.Id,
                                  WxUserId = p.WxuserId,
                                  AvatarUrl = p.UserBaseInfo.AvatarUrl,
                                  NickName = p.UserBaseInfo.NickName,
                                  PlayAge = p.UserBaseInfo.PlayAge,
                                  Gender = p.UserBaseInfo.Gender,
                                  Latitude = p.ExercisePurpose.UserLocation.Latitude,
                                  Longitude = p.ExercisePurpose.UserLocation.Longitude,
                                  ExerciseExplain = p.ExercisePurpose.ExerciseExplain
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
    }
}
