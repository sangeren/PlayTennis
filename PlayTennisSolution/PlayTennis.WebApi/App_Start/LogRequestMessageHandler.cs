using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi
{
    public class LogRequestMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
           HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var rLog = WebApiApplication.MyMapper.Map<RequestLog>(request);
            if (request.Content.Headers.ContentLength > 0 && request.Content.Headers.ContentLength < 1024)
            {
                var stream = new MemoryStream();
                await request.Content.CopyToAsync(stream);
                StreamReader reader = new StreamReader(stream);
                stream.Position = 0;
                string text = reader.ReadToEnd();
                rLog.HttpContent = text;
            }

            // Call the inner handler. 
            // 调用内部处理器。
            var response = await base.SendAsync(request, cancellationToken);
            var resp = WebApiApplication.MyMapper.Map<ResponseLog>(response);

            //记录每次的请求（返回
            var logService = new LogService();
            var log = new LogHttpRequest()
            {
                Requst = JsonConvert.SerializeObject(rLog),
                Response = JsonConvert.SerializeObject(resp),
            };
            logService.LogHttpResquestAsync(log);

            return response;
        }
    }
}