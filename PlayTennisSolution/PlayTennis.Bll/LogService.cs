using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Model;
using PlayTennis.Dal;

namespace PlayTennis.Bll
{
    public class LogService
    {
        public Task LogUserLoginAsync(LogInformation log)
        {
            if (log == null)
            {
                return null;
            }
            var context = new PalyTennisDb();
            context.LogInformation.Add(log);
            context.SaveChanges();
            return null;
        }

        public Task LogHttpResquestAsync(LogHttpRequest log)
        {
            if (log == null)
            {
                return null;
            }
            var context = new PalyTennisDb();
            context.LogHttpRequest.Add(log);
            context.SaveChanges();
            return null;
        }
    }
}
