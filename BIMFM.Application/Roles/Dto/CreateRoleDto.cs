using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using BIMFM.Authorization.Roles;

namespace BIMFM.Roles.Dto
{
    [AutoMapFrom(typeof(Role)), AutoMapTo(typeof(Role))]
    public class CreateRoleDto
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }

        //[StringLength(Role.MaxDisplayNameLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public List<RolePermissionSetting> Permissions { get; set; }
    }
}