using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayTennis.Model.Dto;

namespace PlayTennis.Utility
{
    public class HttpHelper
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string Appid { get; set; }
        public static string Secret { get; set; }

        private static DateTime expiresTime = new DateTime(1991, 1, 1);
        private static string accesToken = "";

        public static string BaiduMapKey { get; set; }

        public static string PostWxMessage(WxTextMessageDto wxText)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + GetAccesToken());

            var result = client.PostAsync("", new StringContent(JsonConvert.SerializeObject(wxText))).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        static HttpHelper()
        {
            //_log.Logger.Repository.Propertie
            //todo 日志记录有问题 ？
            var fileInfo = new FileInfo("c:/webLogs/http-helper/");
            log4net.Config.XmlConfigurator.Configure(fileInfo);

            Appid = ConfigHelper.GetConfigValueOrDefault("Appid", "wxd7c6faee52928e6b");
            Secret = ConfigHelper.GetConfigValueOrDefault("Secret", "d804dfd690de9011e6713a886822e236");

            BaiduMapKey = ConfigHelper.GetConfigValueOrDefault("baiduMapKey", "NGv7mm5W9fOpNGkSqH093PxYLdXKgI3G");
        }

        public static void SendTemplateMessage(string openid, string form_id, string page, List<MessageData> data, string templateid = "BZ5fO_Aw17zcdLm093dClKIUVUPW4DBRpWJemU8IevY")
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.BaseAddress = new Uri("https://api.weixin.qq.com/cgi-bin/message/wxopen/template/send?access_token=" + GetAccesToken());
            //client.DefaultRequestHeaders.

            var message = new TemplateMessage()
            {
                touser = openid,
                template_id = templateid,
                page = page,
                form_id = form_id,
                data = data,
                emphasis_keyword = "keyword1.DATA"
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(message));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("", content).Result.Content.ReadAsStringAsync().Result;

            _log.Info("SendTemplateMessage" + result);
            _log.Info("SendTemplateMessageRequestContent:" + JsonConvert.SerializeObject(message));

            //return result;
        }

        //6omskY50ZQeOKvYQPIVkl2Qkwequq679yWWO3RG6sdwUTe9XU5jgBv9X9gYvVZU7petgrSXW2OeaMYx3tMnwiSzZXxm2aWXt27WTgPWFBhXwDmSac7YmnnxJTVu-5txNOQSdABADFH
        public static void SendTemplateMessageLocal(string openid, string form_id, string page, List<MessageData> data, string templateid = "dITCIwEgwIi562Y-amlKKpd2bEr2ltCRXIfpnkyNLFI")
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.ExpectContinue = false;
            //s api.weixin.qq.com mwSfP6I4A1mCQh4PYxswmGVPg85VKLFhByMDr-AiFfsnFCX-V5LFL4JsDr4BNP_mUZqBnyq_s-QT9o8ipv5_IOT5eeH__OlA5yb4M7EfKh8RG_Rey6GM4ph9eT3xuTriPTZgABABFL
            //client.BaseAddress = new Uri("http://106.14.15.67/cgi-bin/message/custom/send?access_token=pYRPWw4zFx1kO35U-PCQymMHq4MfSpUdYCxdk0nwNo3c2r2Q6pkOFWtDh6ttVk1Vvzd84iq8r5iPEPrwcrRVsGjWw4jRnqDQV08EWMkMK-DpoVTpxTRv-hhDRQRLgBVbGKQfAEAQUA");
            client.BaseAddress = new Uri("https://api.weixin.qq.com/cgi-bin/message/wxopen/template/send?access_token=pYRPWw4zFx1kO35U-PCQymMHq4MfSpUdYCxdk0nwNo3c2r2Q6pkOFWtDh6ttVk1Vvzd84iq8r5iPEPrwcrRVsGjWw4jRnqDQV08EWMkMK-DpoVTpxTRv-hhDRQRLgBVbGKQfAEAQUA");

            var message = new TemplateMessage()
            {
                touser = openid,
                template_id = templateid,
                page = page,
                form_id = form_id,
                data = data,
                emphasis_keyword = "keyword1.DATA"
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(message));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("", content).Result.Content.ReadAsStringAsync().Result;

            _log.Info("SendTemplateMessage" + result);
            _log.Info("SendTemplateMessageRequestContent:" + JsonConvert.SerializeObject(message));

            //return result;
        }
        public static string GetAccesToken()
        {
            if (string.IsNullOrEmpty(accesToken) || DateTime.Now.CompareTo(expiresTime) > 0)
            {
                var client = new HttpClient();

                var result = client.GetStringAsync(new Uri("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + Appid + "&secret=" + Secret)).Result;
                _log.Info("GetAccesToken" + result);
                var token = JsonConvert.DeserializeObject<AccessToken>(result);
                expiresTime = DateTime.Now.AddSeconds(token.expires_in - 30);
                accesToken = token.access_token;
                return token.access_token;
            }
            else
            {
                return accesToken;
            }
        }

        public static LocationInfor GetLocationInfor(string lng, string lat)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.ExpectContinue = false;
            var uri = new Uri("http://api.map.baidu.com/geocoder/v2/?callback=renderReverse&location=" + lat + "," + lng + "&output=json&pois=1&pois=0&ak=" + BaiduMapKey);

            var result = client.GetStringAsync(uri).Result;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Substring(result.IndexOf('(') + 1, result.Length - result.IndexOf('(') - 2);
                var location = JsonConvert.DeserializeObject<BaiduMapResult>(result);
                if (location != null && location.status == 0)
                {
                    return location.result.addressComponent;
                }
            }
            return null;
        }
    }


    //    {
    //  "touser": "OPENID",  
    //  "template_id": "TEMPLATE_ID", 
    //  "page": "index",          
    //  "form_id": "FORMID",         
    //  "data": {
    //      "keyword1": {
    //          "value": "339208499", 
    //          "color": "#173177"
    //      }, 
    //      "keyword2": {
    //          "value": "2015年01月05日 12:30", 
    //          "color": "#173177"
    //      }, 
    //      "keyword3": {
    //          "value": "粤海喜来登酒店", 
    //          "color": "#173177"
    //      } , 
    //      "keyword4": {
    //          "value": "广州市天河区天河路208号", 
    //          "color": "#173177"
    //      } 
    //  },
    //  "emphasis_keyword": "keyword1.DATA" 
    //}

    class TemplateMessage
    {
        public string touser { get; set; }
        public string template_id { get; set; }
        public string page { get; set; }
        public string form_id { get; set; }
        public string emphasis_keyword { get; set; }
        public List<MessageData> data { get; set; }
    }

    public class MessageData
    {
        public string value { get; set; }
        public string color { get; set; }
    }

    class AccessToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    class BaiduMapResult
    {
        public int status { get; set; }
        public LocationResult result { get; set; }
    }

    class LocationResult
    {
        public LocationInfor addressComponent { get; set; }
    }
}
