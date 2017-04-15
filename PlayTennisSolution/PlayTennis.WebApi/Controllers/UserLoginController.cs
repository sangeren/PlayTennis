using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using PlayTennis.Bll;
using PlayTennis.Model.Dto;
using PlayTennis.WebApi.Models;

namespace PlayTennis.WebApi.Controllers
{
    public class UserLoginController : ApiController
    {
        private const string Appid = "wx69499dc511c5b6b7";
        private const string Secret = "dae8ba55fbe5d2fbfca156c17199b4ab";



        public async Task<string> Get(string id, string nickName, string avatarUrl, byte gender)
        //public async Task<string> Get(string id,WxUserLoginDto userLoginDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("code", "参数不合规！");
            }

            var result = "";

            var url =
                string.Format(
                    "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code",
                    Appid, Secret, id);
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var context = await response.Content.ReadAsStringAsync();
                var userLogin = JsonConvert.DeserializeObject<WxLogin>(context);
                if (userLogin != null && userLogin.openid != null)
                {
                    var servic = new UserLoginService();
                    var wxUser = servic.LogUserLogin(new WxUserLoginDto()
                    {
                        Openid = userLogin.openid,
                        SessionKey = userLogin.session_key,
                        //NickName = userLoginDto.NickName,
                        //AvatarUrl = userLoginDto.AvatarUrl,
                        //Gender = userLoginDto.Gender,
                        NickName = nickName,
                        AvatarUrl = avatarUrl,
                        Gender = gender,
                    });
                    result = wxUser.Id.ToString();
                }
            }
            return result;
        }
    }
}