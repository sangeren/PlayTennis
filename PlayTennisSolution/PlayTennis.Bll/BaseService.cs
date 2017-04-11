using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class BaseService<T, TKey> where T : class
    {
        protected GenericRepository<T> MyEntitiesRepository { get; set; }

        public BaseService()
        {
            MyEntitiesRepository = new GenericRepository<T>();
        }
        public T GetEntityByid(TKey id)
        {
            return MyEntitiesRepository.GetById(id);
        }
        public int EditEntity(T t)
        {
            var result = 0;
            if (t == null)
            {
                return result;
            }

            return MyEntitiesRepository.Update(t);
        }
    }
}
