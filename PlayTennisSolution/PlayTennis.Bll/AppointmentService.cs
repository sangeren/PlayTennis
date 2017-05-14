using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayTennis.Dal;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.Bll
{
    public class AppointmentService : BaseService<PlayTennis.Model.Appointment, Guid>
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AppointmentService()
        {
            AppointmentRecordRepository = new GenericRepository<AppointmentRecord>();
        }
        protected GenericRepository<AppointmentRecord> AppointmentRecordRepository { get; set; }

        /// <summary>
        /// 预约列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="type">0：发起；1：接收；2:完成</param>
        /// <returns></returns>
        public IList<AppointmentResultDto> AppointmentList(Guid id, byte type)
        {
            var list = new List<AppointmentResultDto>();
            //            AppointmentRecordRepository.Entities.Where(p=>p.)
            if (type == 0)
            {
                //list=   MyEntitiesRepository.Entities.
                //  Where(p=>p.InitiatorId.Equals(id))
                //  .Select(p=>new AppointmentResultDto
                //  {
                //      AvatarUrl=p.Invitee.AvatarUrl,
                //      NickName=p.Invitee.NickName,
                //      StartTime=p.ExercisePurpose.StartTime,
                //      EndTime=p.ExercisePurpose.EndTime,
                //      e
                //  })
            }
            else if (type == 1)
            {
                list = MyEntitiesRepository.Entities
                    .Where(p => p.InviteeId.Equals(id) && p.AppointmentState.Equals(0))
                    .Select(p => new AppointmentResultDto()
                    {
                        AvatarUrl = p.Initiator.AvatarUrl,
                        NickName = p.Initiator.NickName,
                        StartTime = p.ExercisePurpose.StartTime,
                        EndTime = p.ExercisePurpose.EndTime,
                        ExercisePurposeId = p.ExercisePurposeId,
                        CreateTime = p.CreateTime,

                    })
                    .ToList();
            }
            else if (type == 2)
            {
                list = MyEntitiesRepository.Entities
                  .Where(p => p.InviteeId.Equals(id) && p.AppointmentState.Equals(3))
                  .Select(p => new AppointmentResultDto()
                  {
                      AvatarUrl = p.Initiator.AvatarUrl,
                      NickName = p.Initiator.NickName,
                      StartTime = p.ExercisePurpose.StartTime,
                      EndTime = p.ExercisePurpose.EndTime,
                      ExercisePurposeId = p.ExercisePurposeId,
                      CreateTime = p.CreateTime,

                  })
                  .ToList();
            }

            return list;
        }

        /// <summary>
        /// 发起预约
        /// </summary>
        /// <param name="initiatorId">发起人用户id</param>
        /// <param name="inviteeId">受邀人用户id</param>
        /// <param name="exercisePurposeId">意向id</param>
        /// <param name="formid">提交发起预约表单id</param>
        public void InitatorAppointment(Guid initiatorId, Guid inviteeId, Guid exercisePurposeId, string formid)
        {
            var appointment = new Appointment() { InitiatorId = initiatorId, InviteeId = inviteeId, ExercisePurposeId = exercisePurposeId, AppointmentState = 0 };
            var appointmentRecord = new AppointmentRecord() { Appointment = appointment, AppointmentState = 0, UserBaseInfoId = initiatorId, FormId = formid };


            _log.Info(JsonConvert.SerializeObject(appointmentRecord));
            AppointmentRecordRepository.Insert(appointmentRecord);
        }
        /// <summary>
        /// 接受预约
        /// </summary>
        /// <param name="inviteeId"></param>
        /// <param name="appointmentId"></param>
        public void AcceptAppointment(Guid inviteeId, Guid appointmentId)
        {
            var appointmentRecord =
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId)).OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(0))
            {
                var appointment = MyEntitiesRepository.Entities.Find(appointmentId);
                appointment.AppointmentState = 1;
                appointment.UpdateTime = DateTime.Now;
                var record = new AppointmentRecord() { AppointmentId = appointmentId, AppointmentState = 1, UserBaseInfoId = inviteeId };
                MyEntitiesRepository.UnitOfWork.EnableTransation = true;
                MyEntitiesRepository.Update(appointment);
                AppointmentRecordRepository.Insert(record);
                MyEntitiesRepository.UnitOfWork.SavaChanges();
            }
        }
        /// <summary>
        /// 拒绝预约
        /// </summary>
        /// <param name="inviteeId"></param>
        /// <param name="appointmentId"></param>
        /// <param name="explain"></param>
        public void RefuseAppointment(Guid inviteeId, Guid appointmentId, string explain)
        {
            var appointmentRecord =
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId)).OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(0))
            {
                var appointment = MyEntitiesRepository.Entities.Find(appointmentId);
                appointment.AppointmentState = 2;
                appointment.UpdateTime = DateTime.Now; var record = new AppointmentRecord() { AppointmentId = appointmentId, AppointmentState = 2, UserBaseInfoId = inviteeId, Remark = explain };
                MyEntitiesRepository.UnitOfWork.EnableTransation = true;
                MyEntitiesRepository.Update(appointment);
                AppointmentRecordRepository.Insert(record);
                MyEntitiesRepository.UnitOfWork.SavaChanges();
            }
        }
        /// <summary>
        /// 完成预约
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="appointmentId"></param>
        /// <param name="comment"></param>
        public void FinishAppointment(Guid userId, Guid appointmentId, string comment)
        {
            var appointmentRecord =
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId)).OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(1))
            {
                var appointment = MyEntitiesRepository.Entities.Find(appointmentId);
                appointment.AppointmentState = 3;
                var record = new AppointmentRecord() { AppointmentId = appointmentId, AppointmentState = 3, UserBaseInfoId = userId, Remark = comment };
                MyEntitiesRepository.UnitOfWork.EnableTransation = true;
                MyEntitiesRepository.Update(appointment);
                AppointmentRecordRepository.Insert(record);
                MyEntitiesRepository.UnitOfWork.SavaChanges();
            }
        }
    }
}
