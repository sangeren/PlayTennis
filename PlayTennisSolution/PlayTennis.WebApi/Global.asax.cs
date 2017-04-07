using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace PlayTennis.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IMapper MyMapper { get; set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //记录异常
            GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilterAttribute());

            //创建请求记录映射
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HttpRequestMessage, RequestLog>();
                cfg.CreateMap<HttpResponseMessage, ResponseLog>();

            });
            MyMapper = config.CreateMapper();
        }
    }
}
