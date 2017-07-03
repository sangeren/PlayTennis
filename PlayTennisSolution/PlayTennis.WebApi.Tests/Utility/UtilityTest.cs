using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayTennis.Utility;

namespace PlayTennis.WebApi.Tests.Utility
{
    [TestClass]

    public class UtilityTest
    {
        [TestMethod]
        public void SendTemplateMessage()
        {

            var data = new ListData();
            //预约时间
            var keyword1 = new MessageData() { value = "aa" + "至" + "bb", color = "#173177" };
            //姓名
            var keyword2 = new MessageData() { value = "ddd", color = "#173177" };
            //备注
            var keyword3 = new MessageData() { value = "ddd", color = "#173177" };

            data.keyword1 = keyword1;
            data.keyword2 = keyword2;
            data.keyword3 = keyword3;

            HttpHelper.SendTemplateMessageLocal("o7yTt0DHbe9avqcCoNSPJbcWuyy4",
                "1496927664260", "", data);
        }
        [TestMethod]
        public void GetAccesToken()
        {

            HttpHelper.GetAccesToken();
        }
        [TestMethod]
        public void GetLocationInfor()
        {
            double d1 = 39.983424;
            double d2 = 116.322987;

            HttpHelper.GetLocationInfor(d2.ToString(), d1.ToString());
        }
        //HttpHelper
    }
}
