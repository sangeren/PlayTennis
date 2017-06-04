using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayTennis.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.WebApi.Tests.Controllers
{
    [TestClass]
    public class UserLoginControllerTest
    {
        [TestMethod]
        public async Task Get()
        {
            // 排列
            var controller = new UserLoginController();

            // 操作
            var result = await controller.Get("code", "", "", 1, "", "");

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
            //return Task.FromResult<>();
        }
    }
}
