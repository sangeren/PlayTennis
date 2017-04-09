using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayTennis.WebApi.Controllers;
using PlayTennis.Model.Dto;

namespace PlayTennis.WebApi.Tests.Controllers
{
    [TestClass]
    public class ExercisePurposeControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // 排列
            ValuesController controller = new ValuesController();

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
            var controller = new ExercisePurposeController();

            // 操作
            var result = controller.Get(new Guid("3A584BB9-E512-464C-B43B-C39A9323BBC7"));

            // 断言
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            var controller = new ExercisePurposeController();

            // 操作
            controller.Post(new EditPurposeDto()
            {
                endTime = DateTime.Now,
                exerciseExplain = "运动意向说明",
                isCanChange = true,
                startTime = DateTime.Now,
                userLocation = new LocationDto() { latitude = 1, longitude = 1, speed = 1 },
                wxUserid = new Guid("3A584BB9-E512-464C-B43B-C39A9323BBC7")
            });

            // 断言
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Put()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            controller.Put(5, "value");

            // 断言
        }

        [TestMethod]
        public void Delete()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            controller.Delete(5);

            // 断言
        }
    }
}
