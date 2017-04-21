using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PlayTennis.Model;
using PlayTennis.WebApi.Controllers;

namespace PlayTennis.WebApi.Tests.Controllers
{
    [TestClass]
    public class WeixinMessageControllerTest
    {
        public WeixinMessageControllerTest()
        {
            MyController = new WeixinMessageController();
        }
        public WeixinMessageController MyController { get; set; }
        [TestMethod]
        public void Get()
        {
            // 排列
            var controller = MyController;

            // 操作
            var result = controller.Get("2", 1, 1, 1);

            // 断言
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // 排列
            var controller = MyController;

            // 操作
            var result = controller.Get(2);
            var str = JsonConvert.SerializeObject(result);
            // 断言
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            var controller = MyController;

            // 操作
            controller.Post("");

            // 断言
        }

        [TestMethod]
        public void Put()
        {
            // 排列
            var controller = MyController;
            //var baseInfor = controller.Get();
            ////baseInfor.PlayAge = 2;
            //// 操作
            //controller.Put(baseInfor);

            // 断言
        }

        [TestMethod]
        public void Delete()
        {
            // 排列
            var controller = new BaseInforController();

            // 操作
            controller.Delete(5);

            // 断言
        }
    }
}
