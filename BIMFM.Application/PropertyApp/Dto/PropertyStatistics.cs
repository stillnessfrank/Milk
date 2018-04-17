using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMFM.PropertyApp.Dto
{
    public class PropertyStatistics
    {
        public int PropertyAmount { get; set; }
        public int PropertyHasCertAmount { get; set; }
        public int PropertyNoCertAmount { get; set; }
        public int PropertyUseRightAmount { get; set; }
        public int RoomAmount { get; set; }
        public int TotalArea { get; set; }
    }
}
