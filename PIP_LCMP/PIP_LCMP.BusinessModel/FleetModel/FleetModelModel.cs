using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.BusinessEntities.FleetModel
{
    public class FleetModelModel
    {
        public int Id { get; set; }

        public int FleetId { get; set; }

        public string Name { get; set; }

        public int SMUHours { get; set; }
    }
}
