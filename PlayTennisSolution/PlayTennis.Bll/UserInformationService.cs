using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class UserInformationService
    {
        public PalyTennisDb Context { private get; set; }

        public UserInformationService()
        {
            Context = new PalyTennisDb();
        }

        public UserInformation GetUserInformationById(Guid wxUserid)
        {
            return Context.UserInformation
                .Include(p => p.ExercisePurpose)
                .Include(p => p.UserBaseInfo)
                .Include(p => p.SportsEquipment)
                .Include(p => p.TennisCourts)
                .FirstOrDefault(p => p.WxuserId.Equals(wxUserid));
        }
    }
}
