using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

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
    }
}
