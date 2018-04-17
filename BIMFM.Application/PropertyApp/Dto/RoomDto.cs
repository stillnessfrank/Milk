using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using BIMFM.Entities;
using Abp.AutoMapper;

namespace BIMFM.PropertyApp.Dto
{
    [AutoMap(typeof(Room))]
    public class RoomDto : CreationAuditedEntityDto
    {
        public string Uid { get; set; }
        public string RoomName { get; set; }
        public string RoomCode { get; set; }
        public string BuildingArea { get; set; }
        public string UsageArea { get; set; }
        public string RentStatusCode { get; set; }
        public string CoverPhoto { get; set; }

        public string PropertyCode { get; set; }
        public string CertificateAddress { get; set; }

        public int PropertyId { get; set; }

        public string RentStatus
        {
            get
            {
                switch (RentStatusCode)
                {
                    case "1":
                        return "待租";
                    case "2":
                        return "已租";
                    default:
                        return "";
                }
            }
        }
    }
}
