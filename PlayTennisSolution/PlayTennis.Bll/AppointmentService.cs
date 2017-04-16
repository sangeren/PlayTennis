using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class AppointmentService : BaseService<PlayTennis.Model.Appointment, Guid>
    {
        protected GenericRepository<AppointmentRecord> AppointmentRecordRepository { get; set; }
        public void InitatorAppointment(Guid initiatorId, Guid inviteeId, Guid exercisePurposeId)
        {
            var appointment = new Appointment() { InitiatorId = initiatorId, InviteeId = inviteeId, ExercisePurposeId = exercisePurposeId };
            var appointmentRecord = new AppointmentRecord() { Appointment = appointment, AppointmentState = 0, UserBaseInfoId = initiatorId };

            AppointmentRecordRepository.Insert(appointmentRecord);
        }
        public void AcceptAppointment(Guid inviteeId, Guid appointmentId)
        {
            var appointmentRecord =
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId)).OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(0))
            {
                var record = new AppointmentRecord() { AppointmentId = appointmentId, AppointmentState = 1, UserBaseInfoId = inviteeId };
                AppointmentRecordRepository.Insert(record);
            }
        }
        public void RefuseAppointment(Guid inviteeId, Guid appointmentId, string explain)
        {
            var appointmentRecord =
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId)).OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(0))
            {
                var record = new AppointmentRecord() { AppointmentId = appointmentId, AppointmentState = 2, UserBaseInfoId = inviteeId, Remark = explain };
                AppointmentRecordRepository.Insert(record);
            }
        }
        public void FinishAppointment(Guid userId, Guid appointmentId, string comment)
        {
            var appointmentRecord =
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId)).OrderByDescending(p => p.CreateTime).FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(1))
            {
                var record = new AppointmentRecord() { AppointmentId = appointmentId, AppointmentState = 3, UserBaseInfoId = userId, Remark = comment };
                AppointmentRecordRepository.Insert(record);
            }
        }
    }
}
