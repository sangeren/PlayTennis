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

        public async Task<int> Get(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException("code", "参数不合规！");
                }

                var result = 0;

                var url =
                    string.Format(
                        "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code",
                        Appid, Secret, code);
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var context = await response.Content.ReadAsStringAsync();
                    var userLogin = JsonConvert.DeserializeObject<WxLogin>(context);
                    var servic = new UserLoginService();
                    var count = servic.LogUserLogin(new WxUserLoginDto()
                         {
                             Openid = userLogin.openid,
                             SessionKey = userLogin.session_key
                         });
                    result = count;
                }
                return result;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}