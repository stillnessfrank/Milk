using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using BIMFM.Users;

namespace BIMFM.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class UpdateUserDto: EntityDto<long>
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

        public string Company { get; set; }
        public string Pictures { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

    }
}