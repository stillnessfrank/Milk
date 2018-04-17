using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BIMFM.Roles.Dto;

namespace BIMFM.Roles
{
    public interface IRoleV1AppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>, IApplicationService
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
        Task UpdateRolePermissions(RoleDto input);

        Task<ListResultDto<RoleDto>> GetAllRoles();
        //Task<RoleDto> ACreateRole1(CreateRoleDto input);
        //Task DeleteRole1(EntityDto<int> input);
    }
}
