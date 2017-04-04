using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTennis.Dal;
using PlayTennis.Model;

namespace PlayTennis.Bll
{
    public class ExercisePurposeService
    {
        public PalyTennisDb Context { get; set; }

        public ExercisePurposeService()
        {
            Context = new PalyTennisDb();
        }

        //public IEnumerable<> 
    }
}
