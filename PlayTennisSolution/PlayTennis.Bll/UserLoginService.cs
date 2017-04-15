﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.Bll
{
    public class UserLoginService
    {
        public PalyTennisDb Context { private get; set; }

        public UserLoginService()
        {
            Context = new PalyTennisDb();
        }
        public WxUser LogUserLogin(WxUserLoginDto user)
        {
            if (user != null)
            {
                var userLogin = new WxUserLogin()
                {
                    Id = Guid.NewGuid(),
                    Openid = user.Openid,
                    SessionKey = user.SessionKey,
                    LoginTime = DateTime.Now
                };
                Context.WxUserLogin.Add(userLogin);
                var wxUser = Context.WxUser.FirstOrDefault(p => p.Opneid.Equals(user.Openid));//.Select(p => 1).FirstOrDefault();
                if (wxUser == null)
                {
                    wxUser = new WxUser() { Id = Guid.NewGuid(), Opneid = user.Openid, CreateTime = DateTime.Now };
                    Context.WxUser.Add(wxUser);

                    var baseInfor = new UserBaseInfo() { NickName = user.NickName, AvatarUrl = user.AvatarUrl, NowAddress = "" };
                    Context.UserBaseInfo.Add(baseInfor);

                    var userInfor = new UserInformation()
                      {
                          UserBaseInfo = baseInfor,
                          WxuserId = wxUser.Id
                      };
                    Context.UserInformation.Add(userInfor);
                }

                Context.WxUserLogin.Add(userLogin);
                Context.SaveChanges();
                return wxUser;
            }

            return null;
        }

        public WxUser GetWxUserByuserid(Guid wxUserid)
        {
            return Context.WxUser.FirstOrDefault(p => p.Id.Equals(wxUserid));
        }
    }
}
