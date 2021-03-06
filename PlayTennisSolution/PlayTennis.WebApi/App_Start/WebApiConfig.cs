﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PlayTennis.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            //config.MessageHandlers.Add(new LogRequestMessageHandler());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //记录异常
            //config.Filters.Add(new WebApiExceptionFilterAttribute());
        }
    }
}
