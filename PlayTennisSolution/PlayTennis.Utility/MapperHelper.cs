using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.Utility
{
    public class MapperHelper
    {
        public MapperHelper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //
                // 摘要: 
                //     Creates a mapping configuration from the TSource type to the TDestination
                //     type
                // 类型参数: 
                //   TSource:
                //     Source type
                //   TDestination:
                //     Destination type
                // 返回结果: 
                //     Mapping expression for more configuration options
                //IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();
                cfg.CreateMap<HttpRequestMessage, RequestLog>();
                cfg.CreateMap<HttpResponseMessage, ResponseLog>();

                cfg.CreateMap<UserInformation, UserInformationDto>();


            });
            MyMapper = config.CreateMapper();
        }
        public static IMapper MyMapper { get; set; }

        //创建请求记录映射
        //        var rLog = MapperHelper.MyMapper.Map<RequestLog>(request);
        //
    }
}
