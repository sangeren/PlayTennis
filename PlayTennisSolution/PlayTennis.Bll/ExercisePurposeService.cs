using System;
using System.Collections.Generic;
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
        private PalyTennisDb Context { get; set; }

        public ExercisePurposeService()
        {
            Context = new PalyTennisDb();
        }

        //public IEnumerable<> 

        public int AddPurpose(EditPurposeDto purposeDto, WxUser wxUser)
        {
            var result = 0;
            if (purposeDto == null || wxUser == null)
            {
                return result;
            }

            var purpose = new ExercisePurpose()
            {
                EndTime = purposeDto.endTime,
                ExerciseExplain = purposeDto.exerciseExplain,
                IsCanChange = purposeDto.isCanChange,
                Location = new BaseLocation()
                {
                    Accuracy = purposeDto.location.accuracy,
                    Latitude = purposeDto.location.latitude,
                    Longitude = purposeDto.location.longitude,
                    Speed = purposeDto.location.speed
                },
                StartTime = purposeDto.startTime
            };
            Context.ExercisePurpose.Add(purpose);

            var userInfo = Context.UserInformation.FirstOrDefault(p => p.WxUser.Equals(wxUser));
            if (userInfo == null)
            {
                userInfo = new UserInformation()
                {
                    ExercisePurpose = purpose,
                    WxUser = wxUser
                };
                Context.UserInformation.Add(userInfo);
            }
            else
            {
                userInfo.ExercisePurpose = purpose;
            }

            result = Context.SaveChanges();

            return result;
        }
    }
}
