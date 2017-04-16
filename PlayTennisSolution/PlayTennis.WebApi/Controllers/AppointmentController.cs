using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;

namespace PlayTennis.WebApi.Controllers
{
    public class AppointmentController : ApiController
    {
        public AppointmentController()
        {
            AppointmentService = new AppointmentService();
        }
        public AppointmentService AppointmentService { get; set; }

        // GET: api/Appointment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Appointment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Appointment
        public void Post(Guid id, [FromBody]string value)
        {
        }

        // PUT: api/Appointment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Appointment/5
        public void Delete(int id)
        {
        }
    }
}
