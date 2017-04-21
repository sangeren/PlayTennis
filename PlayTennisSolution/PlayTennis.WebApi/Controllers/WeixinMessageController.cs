using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Model.Dto;
using PlayTennis.Utility;

namespace PlayTennis.WebApi.Controllers
{
    public class WeixinMessageController : ApiController
    {
        // GET: api/WeixinMessage
        public long Get(string signature, long timestamp, long nonce, long echostr)
        {
            return echostr;
        }

        // GET: api/WeixinMessage/5
        public string Get(int id)
        {
            return
                HttpHelper.PostWxMessage(new WxTextMessageDto()
                {
                    msgtype = "text",
                    touser = "ojtoI0SDNuYEW6V2ghBWMQHjdOPY",
                    text = new TextDto() { content = "ni hao" + id }
                });
        }

        // POST: api/WeixinMessage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WeixinMessage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WeixinMessage/5
        public void Delete(int id)
        {
        }
    }
}
