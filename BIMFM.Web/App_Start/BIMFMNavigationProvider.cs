using Abp.Application.Navigation;
using Abp.Localization;
using BIMFM.Authorization;

namespace BIMFM.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class BIMFMNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                            "用户管理",
                            L("UserMgr"),
                            url: "/UserMgr/Index",
                            target: "UserMgr",
                            icon: "/theme/assets/img/stairs1.png"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "资产管理",
                            L("PropertyMgr"),
                            url: "/PropertyMgr/Index",
                            target: "PropertyMgr",
                            icon: "/theme/assets/img/stairs2.png"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "租凭管理",
                            L("RentMgr"),
                            url: "#",
                            target: "RentMgr",
                            icon: "/theme/assets/img/stairs3.png"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "角色管理",
                            L("RoleMgr"),
                            url: "/RoleMgr/Index",
                            target: "RoleMgr",
                            icon: "/theme/assets/img/stairs4.png"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "财务统计",
                            L("FinancialStatistics"),
                            url: "#",
                            target: "FinancialStatistics",
                            icon: "/theme/assets/img/stairs6.png"
                        )
                    );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BIMFMConsts.LocalizationSourceName);
        }
    }
}
