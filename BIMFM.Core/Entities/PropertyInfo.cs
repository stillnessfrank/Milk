using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace BIMFM.Entities
{
    public class PropertyInfo : FullAuditedEntity
    {
        public string Uid { get; set; }
        //权力属性
        public string OwnershipCertificateCode { get; set; }
        public string PropertyOwner { get; set; }
        public string CertificateAddress { get; set; }

        //土地状况
        public string LandNo { get; set; }
        public string Drawing { get; set; }
        public string LegalNature { get; set; }
        public string SourceOfRight { get; set; }
        public string LandUsage { get; set; }
        public string UseDuration { get; set; }
        public string LandArea { get; set; }
        public string IndependentArea { get; set; }
        public string ShareArea { get; set; }
        public string PublicArea { get; set; }

        //房屋状况
        public string NatureOfOwnership { get; set; }
        public string OverallBuildingArea { get; set; }
        public string BuildingNo { get; set; }
        public string BuildingArea { get; set; }
        public string Part { get; set; }
        public string BuildingType { get; set; }
        public string BuildingUsage { get; set; }
        public string Architecture { get; set; }
        public string Floor { get; set; }
        public string CompletionDate { get; set; }

        //其他信息
        public string IssueDate { get; set; }
        public string StorageUnit { get; set; }
        public string ManagementUnit { get; set; }

        public int PropertyId { get; set; }

        public void Copy(PropertyInfo p)
        {
            OwnershipCertificateCode = p.OwnershipCertificateCode;
            PropertyOwner = p.PropertyOwner;
            CertificateAddress = p.CertificateAddress;

            LandNo = p.LandNo;
            Drawing = p.Drawing;
            LegalNature = p.LegalNature;
            SourceOfRight = p.SourceOfRight;
            LandUsage = p.LandUsage;
            UseDuration = p.UseDuration;
            LandArea = p.LandArea;
            IndependentArea = p.IndependentArea;
            ShareArea = p.ShareArea;
            PublicArea = p.PublicArea;

            NatureOfOwnership = p.NatureOfOwnership;
            OverallBuildingArea = p.OverallBuildingArea;
            BuildingNo = p.BuildingNo;
            BuildingArea = p.BuildingArea;
            Part = p.Part;
            BuildingType = p.BuildingType;
            BuildingUsage = p.BuildingUsage;
            Architecture = p.Architecture;
            Floor = p.Floor;
            CompletionDate = p.CompletionDate;

            IssueDate = p.IssueDate;
            StorageUnit = p.StorageUnit;
            ManagementUnit = p.ManagementUnit;
        }
    }
}
