using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace BIMFM.Entities
{
    public class Property : FullAuditedEntity
    {
        public string Uid { get; set; }
        //基本信息
        public string PropertyCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
        public string BuildingName { get; set; }
        public string PropertyRightCode { get; set; }
        public string OutdoorPanoramaUrl { get; set; }
        public string IndoorPanoramaUrl { get; set; }
        public string CoverPhoto { get; set; }

        public void Copy(Property p)
        {
            PropertyCode = p.PropertyCode;
            City = p.City;
            Region = p.Region;
            Lng = p.Lng;
            Lat = p.Lat;
            BuildingName = p.BuildingName;
            PropertyRightCode = p.PropertyRightCode;
            OutdoorPanoramaUrl = p.OutdoorPanoramaUrl;
            IndoorPanoramaUrl = p.IndoorPanoramaUrl;
            CoverPhoto = p.CoverPhoto;
        }
    }

    
}
