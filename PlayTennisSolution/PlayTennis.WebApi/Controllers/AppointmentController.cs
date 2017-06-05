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
        /// <param name="id">用户信息id</param>
        /// <param name="type">0：发起；1：接收；2:完成【有问题】；3 进行的预约</param>
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
            ExercisePurposeService.SaveWxFormId(id, appointment.formId);

            var formId = ExercisePurposeService.GetFormIdByEntityId(appointment.inviteeId);
            if (!string.IsNullOrEmpty(formId))
            {
                var inviteeOpenid = UserLoginService.GetOpenidByUserid(appointment.inviteeId);
                var exercise = ExercisePurposeService.GetPurposeByEntityId(appointment.exercisePurposeId);

                var data = new List<MessageData>();
                //预约时间
                var keyword1 = new MessageData() { value = exercise.StartTime.Value.ToString() + "至" + exercise.EndTime.Value.ToString(), color = "#173177" };
                //姓名
                var keyword2 = new MessageData() { value = inviteeOpenid.Item2, color = "#173177" };
                //备注
                var keyword3 = new MessageData() { value = "", color = "#173177" };

                data.Add(keyword1);
                data.Add(keyword2);
                data.Add(keyword3);

                _log.Info(inviteeOpenid);
                HttpHelper.SendTemplateMessage(inviteeOpenid.Item1, formId, "", data);
            }
        }

        // PUT: api/Appointment/5
        /// <summary>
        /// 更改预约状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appointment"></param>
        public void Put(Guid id, AppointmentDto appointment)
        {
            ExercisePurposeService.SaveWxFormId(id, appointment.formId);


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
