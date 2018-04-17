using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using BIMFM.Users;

namespace BIMFM.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class CreateUserDto
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        [DisableAuditing]
        public string Password { get; set; }
        public int MobileRole { get; set; }
    }
}