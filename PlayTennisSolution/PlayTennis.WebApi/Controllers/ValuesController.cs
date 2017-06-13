using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;

namespace PlayTennis.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        public ValuesController()
        {
            AppointmentService = new AppointmentService();
        }
        public AppointmentService AppointmentService { get; set; }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var count = AppointmentService.GetAppointmentCount();
            return new string[] { "value1", "value2", count.ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
