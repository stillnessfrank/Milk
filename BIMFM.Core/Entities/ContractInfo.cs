using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace BIMFM.Entities
{
    public class ContractInfo : FullAuditedEntity
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

        public void Copy(ContractInfo c)
        {
            RentManagementUnit = c.RentManagementUnit;
            InChargePerson = c.InChargePerson;
            ContractNo = c.ContractNo;
            ContractCirculationNo = c.ContractCirculationNo;
            IsFormatContract = c.IsFormatContract;
            IsBigContract = c.IsBigContract;
            UrbanArea = c.UrbanArea;
            RentAddress = c.RentAddress;
            RentRegion = c.RentRegion;

            Tenant = c.Tenant;
            Contacts = c.Contacts;
            CertificateTypeCode = c.CertificateTypeCode;
            CertificateCode = c.CertificateCode;

            RentLandArea = c.RentLandArea;
            RentBuildingArea = c.RentBuildingArea;
            RentDuration = c.RentDuration;
            StartDate = c.StartDate;
            EndDate = c.EndDate;
            MonthlyRent = c.MonthlyRent;
            YearlyRent = c.YearlyRent;
            MonthlyManagementFee = c.MonthlyManagementFee;
            Deposit = c.Deposit;
            Penalty = c.Penalty;
            PaymentMethod = c.PaymentMethod;
            SigningDate = c.SigningDate;
            UsageCode = c.UsageCode;
            StatusCode = c.StatusCode;
            RentChangeRemark = c.RentChangeRemark;
            Remark = c.Remark;

            TotalAmount = c.TotalAmount;
            MonthlyRentNoTax = c.MonthlyRentNoTax;
            MonthlyManagementFeeNoTax = c.MonthlyManagementFeeNoTax;
            UnitPrice = c.UnitPrice;
            PropertyRight = c.PropertyRight;
            RentPropertyOwner = c.RentPropertyOwner;
        }
    }
}
