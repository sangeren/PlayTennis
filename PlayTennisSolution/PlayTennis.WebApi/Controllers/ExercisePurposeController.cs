﻿using PlayTennis.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    /// <summary>
    /// 运动意向
    /// </summary>
    public class ExercisePurposeController : ApiController
    {
        public LogService LogService { get; set; }
        public UserLoginService UserLoginService { get; set; }
        public ExercisePurposeService ExercisePurposeService { get; set; }
        public ExercisePurposeController()
        {
            LogService = new LogService();
            UserLoginService = new UserLoginService();
            ExercisePurposeService = new ExercisePurposeService();
        }

        // GET: api/EditPurpose
        public IEnumerable<ExercisePurposeDto> Get(Guid id, int pageIndex, int pageSize = 6, double lat = 0, double lon = 0)
        {
            //return new string[] { "value1", "value2" };
            //return ExercisePurposeService.PurposeList(id, pageIndex, pageSize, lat, lon);
            var list = new List<ExercisePurposeDto>();
            list.Add(new ExercisePurposeDto() { AvatarUrl = "http://wx.qlogo.cn/mmopen/vi_32/DYAIOgq83erq4RMdoXEOcrPjvz9swjl0fH1FWuY0cP65NeTjrNiaH5K9jf1AWRX8ibKGbssRZnqTDNUIbMiakyjZw/0", Disdance = 1, ExerciseExplain = "nihao", Gender = 1, PlayAge = 3, WxUserId = new Guid("2B1EC692-1357-491D-A898-DBB909FD9877"), NickName = "nime" });
            list.Add(new ExercisePurposeDto() { AvatarUrl = "http://wx.qlogo.cn/mmopen/vi_32/DYAIOgq83erq4RMdoXEOcrPjvz9swjl0fH1FWuY0cP65NeTjrNiaH5K9jf1AWRX8ibKGbssRZnqTDNUIbMiakyjZw/0", Disdance = 1, ExerciseExplain = "nihao", Gender = 1, PlayAge = 3, WxUserId = new Guid("2B1EC692-1357-491D-A898-DBB909FD9877"), NickName = "nime" });
            list.Add(new ExercisePurposeDto() { AvatarUrl = "http://wx.qlogo.cn/mmopen/vi_32/DYAIOgq83erq4RMdoXEOcrPjvz9swjl0fH1FWuY0cP65NeTjrNiaH5K9jf1AWRX8ibKGbssRZnqTDNUIbMiakyjZw/0", Disdance = 1, ExerciseExplain = "nihao", Gender = 1, PlayAge = 3, WxUserId = new Guid("2B1EC692-1357-491D-A898-DBB909FD9877"), NickName = "nime" });
            return list;
        }

        // GET: api/EditPurpose/5
        public ExercisePurpose Get(Guid id)
        {
            return ExercisePurposeService.GetPurposeById(id);
        }

        // POST: api/EditPurpose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">wxUserid</param>
        /// <param name="purpose"></param>
        public void Post(Guid id, EditPurposeDto purpose)
        {
            var wxUser = UserLoginService.GetWxUserByuserid(id);
            ExercisePurposeService.AddPurpose(purpose, wxUser);
        }

        // PUT: api/EditPurpose/5
        public void Put(EditPurposeDto purpose)
        {
            ExercisePurposeService.EditPurpose(purpose);
        }

        // DELETE: api/EditPurpose/5
        public void Delete(int id)
        {
        }
    }
}
