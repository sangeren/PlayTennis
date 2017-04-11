using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model;

namespace PlayTennis.WebApi.Controllers
{
    public class TennisCourtController : ApiController
    {
        public TennisCourtController()
        {
            UserLoginService = new UserLoginService();
            MyService = new TennisCourtService();
        }
        public UserLoginService UserLoginService { get; set; }
        public TennisCourtService MyService { get; set; }

        // GET: api/TennisCourt
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TennisCourt/5
        // GET: api/SportsEquipment/5
        public TennisCourt Get(Guid id)
        {
            return MyService.GetEntityByid(id);
        }

        // POST: api/SportsEquipment
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="id">wxid</param>
        /// <param name="entity"></param>
        public void Post(Guid id, TennisCourt entity)
        {
            var wxUser = UserLoginService.GetWxUserByuserid(id);
            MyService.AddTennisCourt(entity, wxUser);
        }

        // PUT: api/SportsEquipment/5
        public void Put(TennisCourt entity)
        {
            var oldEntity = MyService.GetEntityByid(entity.Id);
            if (oldEntity != null)
            {
                oldEntity.CourtAddress = entity.CourtAddress;
                oldEntity.CourtName = entity.CourtName;
                oldEntity.OpenTime = entity.OpenTime;
                oldEntity.UserLocation = entity.UserLocation;

                MyService.EditEntity(oldEntity);
            }
        }

        // DELETE: api/TennisCourt/5
        public void Delete(int id)
        {
        }
    }
}
