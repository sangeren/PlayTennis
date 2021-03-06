﻿using System;
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
        private static log4net.ILog _log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AppointmentService()
        {
            AppointmentRecordRepository = new GenericRepository<AppointmentRecord>();
            ExercisePurposeRepository = new GenericRepository<ExercisePurpose>();
            UserInformationRepository = new GenericRepository<UserInformation>();
        }

        protected GenericRepository<AppointmentRecord> AppointmentRecordRepository { get; set; }
        protected GenericRepository<ExercisePurpose> ExercisePurposeRepository { get; set; }
        protected GenericRepository<UserInformation> UserInformationRepository { get; set; }

        /// <summary>
        /// 预约列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="type">0：发起；1：接收；2:完成;3 进行的预约</param>
        /// <returns></returns>
        public IList<AppointmentResultDto> AppointmentList(Guid id, byte type)
        {
            var list = new List<AppointmentResultDto>();
            //AppointmentRecordRepository.Entities.Where(p=>p.)
            var userInfor = UserInformationRepository.Entities.FirstOrDefault(p => p.Id.Equals(id));
            var exercisePurpose =
                ExercisePurposeRepository.Entities.FirstOrDefault(
                    p => p.UserInformationId == id && p.ExerciseState.Equals(0));

            var now = DateTime.Now;
            if (userInfor == null)
            {
                return list;
            }
            if (type == 0)
            {

            }
            else if (type == 1)
            {
                #region MyRegion

                if (exercisePurpose == null)
                {
                    return list;
                }

                list = MyEntitiesRepository.Entities
                    .Where(
                        p =>
                            p.InviteeId.Equals(userInfor.UserBaseInfoId.Value) && p.AppointmentState.Equals(0) &&
                            p.ExercisePurposeId.Equals(exercisePurpose.Id))
                    .Select(p => new AppointmentResultDto()
                    {
                        Id = p.InitiatorId,
                        AvatarUrl = p.Initiator.AvatarUrl,
                        NickName = p.Initiator.NickName,
                        StartTime = p.ExercisePurpose.StartTime,
                        EndTime = p.ExercisePurpose.EndTime,
                        ExercisePurposeId = p.ExercisePurposeId,
                        CreateTime = p.CreateTime,
                        Gender = p.Initiator.Gender,
                        PlayAge = p.Initiator.PlayAge,
                        AppointmentId = p.Id
                    })
                    .ToList();

                #endregion
            }
            else if (type == 2)
            {
                #region MyRegion

                list = MyEntitiesRepository.Entities
                    .Where(
                        p =>
                            (p.InviteeId.Equals(userInfor.UserBaseInfoId.Value) ||
                             p.InitiatorId.Equals(userInfor.UserBaseInfoId.Value))
                            &&
                            (p.AppointmentState.Equals(3) || p.AppointmentState.Equals(4) ||
                             (p.AppointmentState.Equals(1) && p.ExercisePurpose.EndTime.Value.CompareTo(now) <= 0)))
                    .Select(p => new AppointmentResultDto()
                    {
                        Id = p.ExercisePurposeId,
                        AvatarUrl = p.Initiator.AvatarUrl,
                        AvatarUrl2 = p.Invitee.AvatarUrl,
                        NickName = p.Initiator.NickName,
                        NickName2 = p.Invitee.NickName,
                        StartTime = p.ExercisePurpose.StartTime,
                        EndTime = p.ExercisePurpose.EndTime,
                        ExercisePurposeId = p.ExercisePurposeId,
                        CreateTime = p.CreateTime,

                    })
                    .ToList();

                #endregion
            }
            else if (type == 3)
            {
                #region MyRegion

                list = MyEntitiesRepository.Entities
                    .Where(
                        p =>
                            (p.InviteeId.Equals(userInfor.UserBaseInfoId.Value) ||
                             p.InitiatorId.Equals(userInfor.UserBaseInfoId.Value))
                            && p.AppointmentState.Equals(1) && p.ExercisePurpose.EndTime.Value.CompareTo(now) >= 0)
                    .Select(p => new AppointmentResultDto()
                    {
                        Id = p.ExercisePurposeId,
                        AvatarUrl = p.Initiator.AvatarUrl,
                        AvatarUrl2 = p.Invitee.AvatarUrl,
                        NickName = p.Initiator.NickName,
                        NickName2 = p.Invitee.NickName,
                        StartTime = p.ExercisePurpose.StartTime,
                        EndTime = p.ExercisePurpose.EndTime,
                        ExercisePurposeId = p.ExercisePurposeId,
                        CreateTime = p.CreateTime,

                    })
                    .ToList();

                #endregion
            }

            return list;
        }

        public AppointmentInformationDto AppointmentInformation(Guid id)
        {
            var result = new AppointmentInformationDto() { AppointmentCount = 0 };
            //AppointmentRecordRepository.Entities.Where(p=>p.)
            var userInfor = UserInformationRepository.Entities.FirstOrDefault(p => p.Id.Equals(id));
            var exercisePurpose =
                ExercisePurposeRepository.Entities.FirstOrDefault(
                    p => p.UserInformationId == id && p.ExerciseState.Equals(0));
            if (userInfor == null)
            {
                return result;
            }
            if (exercisePurpose == null)
            {
                return result;
            }

            var appointmentCount = MyEntitiesRepository.Entities
                .Count(p => p.InviteeId.Equals(userInfor.UserBaseInfoId.Value) && p.AppointmentState.Equals(0) &&
                            p.ExercisePurposeId.Equals(exercisePurpose.Id));
            result.AppointmentCount = appointmentCount;

            var appointmentReceiveCount = MyEntitiesRepository.Entities
                .Count(p => p.InviteeId.Equals(userInfor.UserBaseInfoId.Value) && p.AppointmentState.Equals(1) &&
                            p.ExercisePurposeId.Equals(exercisePurpose.Id));

            result.ExercisPurposeId = appointmentReceiveCount > 0 ? exercisePurpose.Id.ToString() : null;
            return result;
        }

        /// <summary>
        /// 发起预约
        /// </summary>
        /// <param name="initiatorId">发起人用户id</param>
        /// <param name="inviteeId">受邀人用户id</param>
        /// <param name="exercisePurposeId">意向id</param>
        /// <param name="formid">提交发起预约表单id</param>
        public void InitatorAppointment(Guid initiatorId, Guid inviteeId, Guid exercisePurposeId)
        {
            //var hasAppointment =
            //    MyEntitiesRepository.Entities.Any(
            //        p => p.InitiatorId.Equals(initiatorId) && p.InviteeId.Equals(inviteeId) && p.AppointmentState == 0);
            var hasAppointment =
                MyEntitiesRepository.Entities.Any(
                    p => p.ExercisePurposeId.Equals(exercisePurposeId) && p.AppointmentState != -1 && p.AppointmentState != 0);

            if (hasAppointment)
            {
                return;
            }

            var appointment = new Appointment()
            {
                InitiatorId = initiatorId,
                InviteeId = inviteeId,
                ExercisePurposeId = exercisePurposeId,
                AppointmentState = 0
            };
            var appointmentRecord = new AppointmentRecord()
            {
                Appointment = appointment,
                AppointmentState = 0,
                UserBaseInfoId = initiatorId,
                //FormId = formid
            };


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
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId))
                    .OrderByDescending(p => p.CreateTime)
                    .FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(0))
            {
                var appointment = MyEntitiesRepository.GetById(appointmentId);
                appointment.AppointmentState = 1;
                appointment.UpdateTime = DateTime.Now;
                var record = new AppointmentRecord()
                {
                    AppointmentId = appointmentId,
                    AppointmentState = 1,
                    UserBaseInfoId = inviteeId
                };
                MyEntitiesRepository.UnitOfWork.EnableTransation = true;
                MyEntitiesRepository.Update(appointment);
                AppointmentRecordRepository.Insert(record);
                MyEntitiesRepository.UnitOfWork.SavaChanges();
            }
        }

        public ExercisePurpose GetPurposeByAppointmentId(Guid appointmentId)
        {
            var result =
                MyEntitiesRepository.Entities.Where(p => p.Id.Equals(appointmentId))
                    .Select(p => p.ExercisePurpose)
                    .FirstOrDefault();

            return result;
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
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId))
                    .OrderByDescending(p => p.CreateTime)
                    .FirstOrDefault();
            if (appointmentRecord != null && appointmentRecord.AppointmentState.Equals(0))
            {
                var appointment = MyEntitiesRepository.GetById(appointmentId);
                appointment.AppointmentState = 2;
                appointment.UpdateTime = DateTime.Now;
                var record = new AppointmentRecord()
                {
                    AppointmentId = appointmentId,
                    AppointmentState = 2,
                    UserBaseInfoId = inviteeId,
                    Remark = explain
                };
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
                AppointmentRecordRepository.Entities.Where(p => p.AppointmentId.Equals(appointmentId))
                    .OrderByDescending(p => p.CreateTime)
                    .FirstOrDefault();
            if (appointmentRecord != null &&
                (appointmentRecord.AppointmentState.Equals(1) || appointmentRecord.AppointmentState.Equals(3)))
            {
                var appointment = MyEntitiesRepository.GetById(appointmentId);
                MyEntitiesRepository.UnitOfWork.EnableTransation = true;

                var exercisePurpose =
                    ExercisePurposeRepository.Entities.FirstOrDefault(p => p.Id.Equals(appointment.ExercisePurposeId));
                if (exercisePurpose != null && exercisePurpose.ExerciseState.Equals(0))
                {
                    exercisePurpose.ExerciseState = 1;
                    exercisePurpose.UpdateTime = DateTime.Now;
                    ExercisePurposeRepository.Update(exercisePurpose);
                }

                appointment.AppointmentState = 3;
                var record = new AppointmentRecord()
                {
                    AppointmentId = appointmentId,
                    AppointmentState = 3,
                    UserBaseInfoId = userId,
                    Remark = comment
                };

                MyEntitiesRepository.Update(appointment);
                AppointmentRecordRepository.Insert(record);
                MyEntitiesRepository.UnitOfWork.SavaChanges();
            }
        }

        public int GetAppointmentCount()
        {
            return AppointmentRecordRepository.Entities.Count();
        }
    }
}