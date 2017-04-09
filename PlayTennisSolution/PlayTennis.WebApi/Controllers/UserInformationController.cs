using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    public class UserInformationController : ApiController
    {
        public UserInformationService UserInformationService { get; set; }

        public UserInformationController()
        {
            UserInformationService = new UserInformationService();
        }
        // GET: api/UserInformation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserInformation/5
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">wxUserid</param>
        /// <returns></returns>
        public UserInformation Get(Guid id)
        {
            return UserInformationService.GetUserInformationById(id);
        }

        // POST: api/UserInformation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserInformation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserInformation/5
        public void Delete(int id)
        {
        }
    }
}
