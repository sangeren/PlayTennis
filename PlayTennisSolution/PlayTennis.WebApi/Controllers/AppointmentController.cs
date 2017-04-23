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
        /// <summary>
        /// 预约列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="type">0：发起；1：接收；2:完成</param>
        /// <returns></returns>
        public IList<AppointmentResultDto> Get(Guid id, byte type)
        {
            return AppointmentService.AppointmentList(id, type);
        }

        // POST: api/Appointment
        /// <summary>
        /// 发起预约
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="appointment"></param>
        public void Post(Guid id, AppointmentDto appointment)
        {
            AppointmentService.InitatorAppointment(id, appointment.inviteeId, appointment.exercisePurposeId);
        }


        // PUT: api/Appointment/5
        public void Put(Guid id, AppointmentDto appointment)
        {
            if (appointment.ActionType == 0)
            {
                AppointmentService.AcceptAppointment(id, appointment.appointmentId);
            }
            else if (appointment.ActionType == 1)
            {
                AppointmentService.RefuseAppointment(id, appointment.appointmentId, appointment.explain);
            }
            else if (appointment.ActionType == 2)
            {
                AppointmentService.FinishAppointment(id, appointment.appointmentId, appointment.comment);
            }
        }

        // DELETE: api/Appointment/5
        public void Delete(int id)
        {
        }
    }
}
