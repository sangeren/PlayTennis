﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayTennis.Model.Dto;

namespace PlayTennis.Utility
{
    public class HttpHelper
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public const string Appid = "wx69499dc511c5b6b7";
        public const string Secret = "dae8ba55fbe5d2fbfca156c17199b4ab";

        private static DateTime expiresTime = new DateTime(1991, 1, 1);
        private static string accesToken = "";

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
            var fileInfo = new FileInfo("c:/webLogs/http-helper/");
            log4net.Config.XmlConfigurator.Configure(fileInfo);
        }

        public static void SendTemplateMessage(string openid, string form_id, string page, List<MessageData> data, string templateid = "dITCIwEgwIi562Y-amlKKpd2bEr2ltCRXIfpnkyNLFI")
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + GetAccesToken());

            var message = new TemplateMessage()
            {
                touser = openid,
                template_id = templateid,
                page = page,
                form_id = form_id,
                data = data,
                emphasis_keyword = ""
            };

            var result = client.PostAsync("", new StringContent(JsonConvert.SerializeObject(message))).Result.Content.ReadAsStringAsync().Result;
            _log.Info("SendTemplateMessage" + result);

            //return result;
        }

        //6omskY50ZQeOKvYQPIVkl2Qkwequq679yWWO3RG6sdwUTe9XU5jgBv9X9gYvVZU7petgrSXW2OeaMYx3tMnwiSzZXxm2aWXt27WTgPWFBhXwDmSac7YmnnxJTVu-5txNOQSdABADFH
        public static void SendTemplateMessageLocal(string openid, string form_id, string page, List<MessageData> data, string templateid = "dITCIwEgwIi562Y-amlKKpd2bEr2ltCRXIfpnkyNLFI")
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=6omskY50ZQeOKvYQPIVkl2Qkwequq679yWWO3RG6sdwUTe9XU5jgBv9X9gYvVZU7petgrSXW2OeaMYx3tMnwiSzZXxm2aWXt27WTgPWFBhXwDmSac7YmnnxJTVu-5txNOQSdABADFH");

            var message = new TemplateMessage()
            {
                touser = openid,
                template_id = templateid,
                page = page,
                form_id = form_id,
                data = data,
                emphasis_keyword = ""
            };

            var result = client.PostAsync("", new StringContent(JsonConvert.SerializeObject(message))).Result.Content.ReadAsStringAsync().Result;
            _log.Info("SendTemplateMessage" + result);

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
}
