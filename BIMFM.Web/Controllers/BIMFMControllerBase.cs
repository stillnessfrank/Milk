using Abp.Authorization;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using BIMFM.Authorization;
using Microsoft.AspNet.Identity;

namespace BIMFM.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    /// 
    
    public abstract class BIMFMControllerBase : AbpController
    {
        protected BIMFMControllerBase()
        {
            LocalizationSourceName = BIMFMConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}