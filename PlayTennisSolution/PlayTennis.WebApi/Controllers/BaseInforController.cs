﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    public class BaseInforController : ApiController
    {
        public LogService LogService { get; set; }
        public UserLoginService UserLoginService { get; set; }
        public BaseInforService BaseInforService { get; set; }
        public UserInformationService UserInformationService { get; set; }
        public BaseInforController()
        {
            LogService = new LogService();
            UserLoginService = new UserLoginService();
            BaseInforService = new BaseInforService();
            UserInformationService = new UserInformationService();
        }
        // GET: api/BaseInfor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BaseInfor/5
        public UserBaseInfo Get(Guid id)
        {
            var userInfor = UserInformationService.GetUserInformationById(id);
            if (userInfor != null && userInfor.UserBaseInfoId != null)
            {
                return BaseInforService.GetEntityByid(userInfor.UserBaseInfoId.Value);
            }
            return null;
        }

        // POST: api/BaseInfor
        /// <summary>
        /// 新增基本信息
        /// </summary>
        /// <param name="id">wxid</param>
        /// <param name="baseInfo"></param>
        public void Post(Guid id, UserBaseInfo baseInfo)
        {
            var wxUser = UserLoginService.GetWxUserByuserid(id);
            BaseInforService.AddBaseInfor(baseInfo, wxUser);
        }

        // PUT: api/BaseInfor/5
        public void Put(UserBaseInfo baseInfo)
        {
            var oldBaseInfor = BaseInforService.GetEntityByid(baseInfo.Id);
            if (oldBaseInfor != null)
            {
                oldBaseInfor.Gender = baseInfo.Gender;
                oldBaseInfor.NickName = baseInfo.NickName;
                oldBaseInfor.NowAddress = baseInfo.NowAddress;
                oldBaseInfor.PlayAge = baseInfo.PlayAge;

                BaseInforService.EditEntity(oldBaseInfor);
            }
        }

        // DELETE: api/BaseInfor/5
        public void Delete(int id)
        {
        }
    }
}
