﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayTennis.WebApi.Controllers;

namespace PlayTennis.WebApi.Tests.Controllers
{
    [TestClass]
    public class UserInformationControllerTest
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
            var controller = new UserInformationController();

            // 操作
            var result = controller.Get(new Guid("1aca638b-bf76-483f-bf15-1629219fc0a0"));
            //var result = controller.Get(new Guid("3A584BB9-E512-464C-B43B-C39A9323BBC7"));

            // 断言
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 操作
            controller.Post("value");

            // 断言
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
