using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PlayTennis.WebApi.Controllers;
using PlayTennis.Model;
using PlayTennis.Model.Dto;

namespace PlayTennis.WebApi.Tests.Controllers
{
    [TestClass]
    public class AppointmentControllerTest
    {
        public AppointmentControllerTest()
        {
            MyController = new AppointmentController();
        }
        public AppointmentController MyController { get; set; }
        [TestMethod]
        public void Get()
        {
            // 排列
            var controller = MyController;
            var tc = new TennisCourt() { UserLocation = new BaseLocation() { } };
            var str = JsonConvert.SerializeObject(tc);

            // 操作
            IEnumerable<string> result = controller.Get();

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }


        [TestMethod]
        public void Post()
        {
            // 排列
            var controller = MyController;

            // 操作
            controller.Post(new Guid("1AE7E30B-E573-4CD6-8534-6E8331FEA8E2"), new AppointmentDto() { inviteeId = new Guid("111B7225-9B13-421A-B492-6E95576B7D3F") });

            // 断言
        }

    }
}
