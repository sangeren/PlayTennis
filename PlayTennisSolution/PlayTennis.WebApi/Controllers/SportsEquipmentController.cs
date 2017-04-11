using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    public class SportsEquipmentController : ApiController
    {
        public SportsEquipmentController()
        {
            UserLoginService = new UserLoginService();
            MyService = new SportsEquipmentService();
        }
        public UserLoginService UserLoginService { get; set; }
        public SportsEquipmentService MyService { get; set; }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SportsEquipment/5
        public SportsEquipment Get(Guid id)
        {
            return MyService.GetEntityByid(id);
        }

        // POST: api/SportsEquipment
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id">wxid</param>
        /// <param name="entity"></param>
        public void Post(Guid id, SportsEquipment entity)
        {
            var wxUser = UserLoginService.GetWxUserByuserid(id);
            MyService.AddSportsEquipment(entity, wxUser);
        }

        // PUT: api/SportsEquipment/5
        public void Put(SportsEquipment entity)
        {
            var oldEntity = MyService.GetEntityByid(entity.Id);
            if (oldEntity != null)
            {
                oldEntity.TennisCount = entity.TennisCount;
                oldEntity.TennisRacketCount = entity.TennisRacketCount;

                MyService.EditEntity(oldEntity);
            }
        }

        // DELETE: api/SportsEquipment/5
        public void Delete(int id)
        {
        }
        
    }
}