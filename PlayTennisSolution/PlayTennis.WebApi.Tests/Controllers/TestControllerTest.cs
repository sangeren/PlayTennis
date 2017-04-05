using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayTennis.WebApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PlayTennis.WebApi.Tests.Controllers
{
    [TestClass]
    public class TestControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // 排列
            var controller = new TestController();

            // 操作
            IEnumerable<string> result = controller.Get();

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void Get2()
        {
            // 排列
            //var controller = new TestController();
            var client=new HttpClient();

            var result = client.GetStringAsync("http://localhost:46704/api/test");
            var content = result.Result;

            Assert.IsNotNull(content);

            // 操作
            //IEnumerable<string> result = controller.Get();
            // 断言
            //Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            //var controller = new TestController();
            var client = new HttpClient();

            var result = client.PostAsync("http://localhost:46704/api/test",new FormUrlEncodedContent(new KeyValuePair<string, string>[]{new KeyValuePair<string, string>("33","33"), }));
            var content = result.Result;

            Assert.IsNotNull(content);

            // 操作
            //IEnumerable<string> result = controller.Get();
            // 断言
            //Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }
    }
}
