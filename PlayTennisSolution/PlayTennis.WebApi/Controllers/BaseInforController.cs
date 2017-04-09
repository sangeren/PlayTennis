using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    public class BaseInforController : ApiController
    {
        // GET: api/BaseInfor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BaseInfor/5
        public UserBaseInfo Get(int id)
        {
            return new UserBaseInfo();
        }

        // POST: api/BaseInfor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BaseInfor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BaseInfor/5
        public void Delete(int id)
        {
        }
    }
}
