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

        public int LogUserLogin(WxUserLoginDto user)
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
                var count = context.SaveChanges();
                return count;
            }

            return 0;
        }
    }
}
