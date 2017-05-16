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
    public class HistoryPlayerController : ApiController
    {
        public AppointmentService AppointmentService { get; set; }

        public HistoryPlayerController()
        {
            AppointmentService = new AppointmentService();

        }
        // GET: api/HistoryPlayer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HistoryPlayer/5
        /// <summary>
        /// 根据用户信息id获取过往球友信息；1 收到的预约个数；2 进行的预约id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AppointmentInformationDto Get(Guid id)
        {
            return AppointmentService.AppointmentInformation(id);
        }

        // POST: api/HistoryPlayer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HistoryPlayer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HistoryPlayer/5
        public void Delete(int id)
        {
        }
    }
}
