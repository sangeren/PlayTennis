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
    public class SportsEquipmentControllerTest
    {
        public SportsEquipmentControllerTest()
        {
            MyController = new SportsEquipmentController();
        }
        public SportsEquipmentController MyController { get; set; }
        [TestMethod]
        public void Get()
        {
            // 排列
            var controller = MyController;

            // 操作
            IEnumerable<string> result = controller.Get();

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // 排列
            var controller = MyController;

            // 操作
            var result = controller.Get(new Guid("4427AAD3-38A3-4B37-964F-CD564E5E4402"));
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
            controller.Post(new Guid("1AE7E30B-E573-4CD6-8534-6E8331FEA8E2"),
                new SportsEquipment() { TennisRacketCount = 1, TennisCount = 0 });

            // 断言
        }

        [TestMethod]
        public void Put()
        {
            // 排列
            var controller = MyController;
            var baseInfor = controller.Get(new Guid("4427AAD3-38A3-4B37-964F-CD564E5E4402"));
            //baseInfor.PlayAge = 2;
            // 操作
            controller.Put(baseInfor);

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
