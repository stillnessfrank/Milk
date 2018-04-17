using System.Threading.Tasks;
using Abp.Application.Services;
using BIMFM.Roles.Dto;

namespace BIMFM.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
