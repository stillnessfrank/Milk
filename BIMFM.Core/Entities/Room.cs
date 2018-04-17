using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace BIMFM.Entities
{
    public class Room : FullAuditedEntity
    {
        public string Uid { get; set; }
        public string RoomName { get; set; }
        public string RoomCode { get; set; }
        public string BuildingArea { get; set; }
        public string UsageArea { get; set; }
        public string RentStatusCode { get; set; }
        public string CoverPhoto { get; set; }

        public int PropertyId { get; set; }

        public void Copy(Room r)
        {
            RoomName = r.RoomName;
            RoomCode = r.RoomCode;
            BuildingArea = r.BuildingArea;
            UsageArea = r.UsageArea;
            RentStatusCode = r.RentStatusCode;
            CoverPhoto = r.CoverPhoto;
            PropertyId = r.PropertyId;
        }
    }
}
