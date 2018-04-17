using Abp.Authorization;
using BIMFM.Authorization.Roles;
using BIMFM.MultiTenancy;
using BIMFM.Users;

namespace BIMFM.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
