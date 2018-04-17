using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using BIMFM.Authorization.Roles;
using BIMFM.Users;

namespace BIMFM.Roles.Dto
{
    [AutoMapFrom(typeof(Role)), AutoMapTo(typeof(Role))]
    public class RoleDto : EntityDto<int>
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string DisplayName { get; set; }

        [StringLength(Role.MaxDisplayNameLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public List<RolePermissionSetting> Permissions { get; set; }

        public List<string> PermissionsStr { get; set; }

        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long LastModifierUserId { get; set; }

        public string CreationTimeStr
        {
            get { return CreationTime.ToString("yyyy-MM-dd hh-mm-ss"); }
        }

        public string LastModificationTimeStr
        {
            get
            {
                if (LastModificationTime == null)
                {
                    return "";
                }
                return LastModificationTime.Value.ToString("yyyy-MM-dd hh-mm-ss");
            }
        }

        public string LastModifierUserName { get; set; }

    }
}
