using PlayTennis.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    /// <summary>
    /// 运动意向
    /// </summary>
    public class ExercisePurposeController : ApiController
    {
        public LogService LogService { get; set; }
        public UserLoginService UserLoginService { get; set; }
        public ExercisePurposeService ExercisePurposeService { get; set; }
        public ExercisePurposeController()
        {
            LogService = new LogService();
            UserLoginService = new UserLoginService();
            ExercisePurposeService = new ExercisePurposeService();
        }

        // GET: api/EditPurpose
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EditPurpose/5
        public string Get(int id)
        {
            var a = new EditPurposeDto();
            a.location = new LocationDto() { latitude = 3 };

            return JsonConvert.SerializeObject(a);
        }

        // POST: api/EditPurpose
        public void Post(EditPurposeDto purpose)
        {
            var wxUser = UserLoginService.GetWxUserByuserid(purpose.wxUserid);
            ExercisePurposeService.AddPurpose(purpose, wxUser);
        }

        // PUT: api/EditPurpose/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EditPurpose/5
        public void Delete(int id)
        {
        }
    }
}
