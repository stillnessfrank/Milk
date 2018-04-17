using System.Threading.Tasks;
using Abp.Auditing;
using Abp.AutoMapper;
using BIMFM.Entities;
using BIMFM.Sessions.Dto;

namespace BIMFM.Sessions
{
    public class SessionAppService : BIMFMAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput();

            if (AbpSession.UserId.HasValue)
            {
                output.User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>();
            }

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
            }

            return output;
        }

    }
}