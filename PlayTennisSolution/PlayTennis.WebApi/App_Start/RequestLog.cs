using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PlayTennis.WebApi
{
    public class RequestLog
    {
        // 摘要: 
        //     获取或设置 HTTP 消息的内容。
        //
        // 返回结果: 
        //     返回 System.Net.Http.HttpContent。 消息的内容
        public HttpContent Content { get; set; }
        //
        // 摘要: 
        //     获取 HTTP 请求标头的集合。
        //
        // 返回结果: 
        //     返回 System.Net.Http.Headers.HttpRequestHeaders。 HTTP 请求标头的集合。
        public HttpRequestHeaders Headers { get; set; }
        //
        // 摘要: 
        //     获取或设置 HTTP 请求信息使用的 HTTP 方法。
        //
        // 返回结果: 
        //     返回 System.Net.Http.HttpMethod。 被请求消息使用的HTTP 方法。 GET 是默认方法。
        public HttpMethod Method { get; set; }
        //
        // 摘要: 
        //     获取或设置 HTTP 请求的 System.Uri。
        //
        // 返回结果: 
        //     返回 System.Uri。 用于 HTTP 请求的 System.Uri。
        public Uri RequestUri { get; set; }
        //
        // 摘要: 
        //     获取或设置 HTTP 消息版本。
        //
        // 返回结果: 
        //     返回 System.Version。 HTTP 消息版本。 默认值为 1.1。
        public Version Version { get; set; }
        /// <summary>
        /// 报文内容
        /// </summary>
        public string HttpContent { get; set; }
    }

    public class ResponseLog
    {
        // 摘要: 
        //     获取或设置 HTTP 响应消息的内容。
        //
        // 返回结果: 
        //     返回 System.Net.Http.HttpContent。 HTTP 响应消息的内容。
        public HttpContent Content { get; set; }
        //
        // 摘要: 
        //     获取 HTTP 响应标头的集合。
        //
        // 返回结果: 
        //     返回 System.Net.Http.Headers.HttpResponseHeaders。 HTTP 响应标头的集合。
        public HttpResponseHeaders Headers { get; set; }
        //
        // 摘要: 
        //     获取一个值，该值指示 HTTP 响应是否成功。
        //
        // 返回结果: 
        //     返回 System.Boolean。 指示 HTTP 响应是否成功的值。 如果 System.Net.Http.HttpResponseMessage.StatusCode
        //     在 200-299 范围中，则为 true；否则为 false。
        public bool IsSuccessStatusCode { get; set; }
        //
        // 摘要: 
        //     获取或设置服务器与状态代码通常一起发送的原因短语。
        //
        // 返回结果: 
        //     返回 System.String。 服务器发送的原因词组。
        public string ReasonPhrase { get; set; }
        //
        // 摘要: 
        //     获取或设置 HTTP 响应的状态代码。
        //
        // 返回结果: 
        //     返回 System.Net.HttpStatusCode。 HTTP 响应的状态代码。
        public HttpStatusCode StatusCode { get; set; }
        //
        // 摘要: 
        //     获取或设置 HTTP 消息版本。
        //
        // 返回结果: 
        //     返回 System.Version。 HTTP 消息版本。 默认值为 1.1。
        public Version Version { get; set; }
    }
}