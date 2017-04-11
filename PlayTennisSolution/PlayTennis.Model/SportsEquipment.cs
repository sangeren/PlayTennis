using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Model
{
    public class SportsEquipment : BaseEntity
    {
        public SportsEquipment()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public int? TennisRacketCount { get; set; }
        public int? TennisCount { get; set; }

    }
}
