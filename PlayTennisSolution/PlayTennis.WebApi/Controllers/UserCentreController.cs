using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model.Dto;

namespace PlayTennis.WebApi.Controllers
{
    public class UserCentreController : ApiController
    {
        public UserCentreController()
        {
            UserInformationService = new UserInformationService();
        }
        // GET: api/UserCentre
        public UserInformationService UserInformationService { get; set; }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserCentre/5
        public UserCentreDto Get(Guid id)
        {
            return UserInformationService.GetUserCentreDto(id);
        }

        // POST: api/UserCentre
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserCentre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserCentre/5
        public void Delete(int id)
        {
        }
    }
}
