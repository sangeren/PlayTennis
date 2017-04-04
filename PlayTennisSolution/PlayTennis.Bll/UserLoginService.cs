using System;
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
                var context = new PalyTennisDb();
                context.WxUserLogin.Add(userLogin);
                var wxUser = context.WxUser.FirstOrDefault(p => p.Opneid.Equals(user.Openid));//.Select(p => 1).FirstOrDefault();
                if (wxUser == null)
                {
                    wxUser = new WxUser() { Id = Guid.NewGuid(), Opneid = user.Openid, CreateTime = DateTime.Now };
                    context.WxUser.Add(wxUser);
                }
                context.WxUserLogin.Add(userLogin);
                context.SaveChanges();
                return wxUser;
            }

            return null;
        }
    }
}
