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
            var data = new List<MessageData>();
            var keyword1 = new MessageData() { value = "您预约的京东商品活动将您预约的京东商品活动将", color = "#173177" };
            var keyword2 = new MessageData() { value = "caohua", color = "#173177" };
            var keyword3 = new MessageData() { value = "2015年01月05日 12:30", color = "#173177" };
            var keyword4 = new MessageData() { value = "备注", color = "#173177" };

            data.Add(keyword1);
            data.Add(keyword2);
            data.Add(keyword3);
            data.Add(keyword4);
            HttpHelper.SendTemplateMessageLocal("ojtoI0fB6O2MVGLVByyq4BS1IJOI",
                "1494852227928", "", data);
        }
        [TestMethod]
        public void GetAccesToken()
        {

            HttpHelper.GetAccesToken();
        }
        [TestMethod]
        public void GetLocationInfor()
        {
            double d1 = 31.273418;
            double d2 = 121.532906;

            HttpHelper.GetLocationInfor(d2.ToString(), d1.ToString());
        }
        //HttpHelper
    }
}
