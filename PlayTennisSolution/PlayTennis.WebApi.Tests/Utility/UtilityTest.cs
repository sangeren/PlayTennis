using System;
using System.Collections.Generic;
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
            var keyword1 = new MessageData() { value = "预约内容" };
            var keyword2 = new MessageData() { value = "预约人" };
            var keyword3 = new MessageData() { value = "预约时间" };
            var keyword4 = new MessageData() { value = "备注" };

            data.Add(keyword1);
            data.Add(keyword2);
            data.Add(keyword3);
            data.Add(keyword4);
            HttpHelper.SendTemplateMessage("ojtoI0SDNuYEW6V2ghBWMQHjdOPY",
                "dITCIwEgwIi562Y-amlKKpd2bEr2ltCRXIfpnkyNLFI", "1494686230870", data);
        }
        [TestMethod]
        public void GetAccesToken()
        {

            HttpHelper.GetAccesToken();
        }

    }
}
