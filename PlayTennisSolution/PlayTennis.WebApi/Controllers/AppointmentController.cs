using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model.Dto;
using PlayTennis.Utility;

namespace PlayTennis.WebApi.Controllers
{
    public class AppointmentController : ApiController
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AppointmentController()
        {
            AppointmentService = new AppointmentService();
            UserLoginService = new UserLoginService();
            ExercisePurposeService = new ExercisePurposeService();
        }
        public AppointmentService AppointmentService { get; set; }
        public UserLoginService UserLoginService { get; set; }
        public ExercisePurposeService ExercisePurposeService { get; set; }

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
            AppointmentService.InitatorAppointment(id, appointment.inviteeId, appointment.exercisePurposeId, appointment.formId);
            var formId = ExercisePurposeService.GetFormIdByEntityId(appointment.exercisePurposeId);
            if (!string.IsNullOrEmpty(formId))
            {
                var inviteeOpenid = UserLoginService.GetOpenidByUserid(appointment.inviteeId);
                var exercise = ExercisePurposeService.GetPurposeByEntityId(appointment.exercisePurposeId);

                var data = new List<MessageData>();
                var keyword1 = new MessageData() { value = "预约内容", color = "#173177" };
                var keyword2 = new MessageData() { value = "预约人", color = "#173177" };
                var keyword3 = new MessageData() { value = "预约时间", color = "#173177" };
                var keyword4 = new MessageData() { value = "备注", color = "#173177" };

                data.Add(keyword1);
                data.Add(keyword2);
                data.Add(keyword3);
                data.Add(keyword4);

                _log.Info(inviteeOpenid);
                HttpHelper.SendTemplateMessage(inviteeOpenid, formId, "", data);
            }
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
