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
    [AutoMap(typeof(ContractInfo))]
    public class ContractInfoDto : CreationAuditedEntityDto
    {
        public string Uid { get; set; }
        //基本信息
        public string RentManagementUnit { get; set; }
        public string InChargePerson { get; set; }
        public string ContractNo { get; set; }
        public string ContractCirculationNo { get; set; }
        public string IsFormatContract { get; set; }
        public string IsBigContract { get; set; }
        public string UrbanArea { get; set; }
        public string RentAddress { get; set; }
        public string RentRegion { get; set; }

        //租户信息
        public string Tenant { get; set; }
        public string Contacts { get; set; }
        public string CertificateTypeCode { get; set; }
        public string CertificateCode { get; set; }

        //租赁信息
        public string RentLandArea { get; set; }
        public string RentBuildingArea { get; set; }
        public string RentDuration { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MonthlyRent { get; set; }
        public string YearlyRent { get; set; }
        public string MonthlyManagementFee { get; set; }
        public string Deposit { get; set; }
        public string Penalty { get; set; }
        public string PaymentMethod { get; set; }
        public string SigningDate { get; set; }
        public string UsageCode { get; set; }
        public string StatusCode { get; set; }
        public string RentChangeRemark { get; set; }
        public string Remark { get; set; }

        //其他信息
        public string TotalAmount { get; set; }
        public string MonthlyRentNoTax { get; set; }
        public string MonthlyManagementFeeNoTax { get; set; }
        public string UnitPrice { get; set; }
        public string PropertyRight { get; set; }
        public string RentPropertyOwner { get; set; }

        public int PropertyId { get; set; }

        public string Usage
        {
            get
            {
                switch (UsageCode)
                {
                    case "1":
                        return "经营";
                    case "2":
                        return "办公";
                    case "3":
                        return "居住";
                    case "4":
                        return "厂房";
                    case "5":
                        return "仓储";
                    case "6":
                        return "农业、副业、畜牧业";
                    case "7":
                        return "宿舍";
                    case "8":
                        return "通信基站";
                    case "9":
                        return "广告位";
                    case "10":
                        return "其他";
                    default:
                        return "";
                }
            }
        }

        public string CertificateType
        {
            get
            {
                switch (CertificateTypeCode)
                {
                    case "1":
                        return "身份证";
                    default:
                        return "";
                }
            }
        }

        public string Status
        {
            get
            {
                switch (StatusCode)
                {
                    case "1":
                        return "正常";
                    case "2":
                        return "中止";
                    case "3":
                        return "待签订";
                    case "4":
                        return "房屋占用";
                    default:
                        return "";
                }
            }
        }
    }
}
