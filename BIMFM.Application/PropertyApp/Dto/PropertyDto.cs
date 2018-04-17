using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BIMFM.Entities;

namespace BIMFM.PropertyApp.Dto
{
    [AutoMap(typeof(Property))]
    public class PropertyDto : CreationAuditedEntityDto
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

        public string PropertyRight
        {
            get
            {
                switch (PropertyRightCode)
                {
                    case "1":
                        return "有产权证";
                    case "2":
                        return "无产权证";
                    case "3":
                        return "有使用权";
                    default:
                        return "";
                }
            }
        }

        public PropertyInfoDto PropertyInfo { get; set; }
        public ContractInfoDto ContractInfo { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
