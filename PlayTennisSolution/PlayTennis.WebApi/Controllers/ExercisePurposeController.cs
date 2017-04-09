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
        public ExercisePurpose Get(Guid id)
        {
            return ExercisePurposeService.GetPurposeById(id);
        }

        // POST: api/EditPurpose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">wxUserid</param>
        /// <param name="purpose"></param>
        public void Post(Guid id, EditPurposeDto purpose)
        {
            var wxUser = UserLoginService.GetWxUserByuserid(id);
            ExercisePurposeService.AddPurpose(purpose, wxUser);
        }

        // PUT: api/EditPurpose/5
        public void Put(EditPurposeDto purpose)
        {
            ExercisePurposeService.EditPurpose(purpose);
        }

        // DELETE: api/EditPurpose/5
        public void Delete(int id)
        {
        }
    }
}
