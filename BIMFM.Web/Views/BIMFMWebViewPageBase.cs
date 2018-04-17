using Abp.Web.Mvc.Views;

namespace BIMFM.Web.Views
{
    public abstract class BIMFMWebViewPageBase : BIMFMWebViewPageBase<dynamic>
    {

    }

    public abstract class BIMFMWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected BIMFMWebViewPageBase()
        {
            LocalizationSourceName = BIMFMConsts.LocalizationSourceName;
        }
    }
}