using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BIMFM.Roles.Dto;
using BIMFM.Users.Dto;

namespace BIMFM.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<UserListDto>> GetUsers();

        Task CreateUser(CreateUserInput input);
        Task UpdateUser(UpdateUserDto input);
        Task DeleteUser(EntityDto<long> input);

        Task<UserListDto> GetUserById(int id);

        Task<ListResultDto<RoleDto>> GetRoles();
    }
}