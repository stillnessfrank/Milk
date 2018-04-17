using System.Collections.Generic;
using BIMFM.Roles.Dto;
using BIMFM.Users.Dto;

namespace BIMFM.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}