using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BIMFM.Authorization
{
    public class BIMFMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);

            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var space = pages.CreateChildPermission(PermissionNames.Pages_Space, L("Space"));

            var space_SpaceInfo = pages.CreateChildPermission(PermissionNames.Pages_Space_SpaceInfo, L("SpaceInfo"));

            var space_Tenant = pages.CreateChildPermission(PermissionNames.Pages_Space_Tenant, L("Tenant"));

            var space_TenantContract = pages.CreateChildPermission(PermissionNames.Pages_Space_TenantContract, L("TenantContract"));

            var space_TenantContractRelationship = pages.CreateChildPermission(PermissionNames.Pages_Space_TenantContractRelationship, L("TenantContractRelationship"));

            var space_SpaceArrangement = pages.CreateChildPermission(PermissionNames.Pages_Space_SpaceArrangement, L("SpaceArrangement"));

            var space_SpaceManagementCenter = pages.CreateChildPermission(PermissionNames.Pages_Space_SpaceManagementCenter, L("SpaceManagementCenter"));

            var asset = pages.CreateChildPermission(PermissionNames.Pages_Asset, L("Asset"));

            var asset_AssetList = pages.CreateChildPermission(PermissionNames.Pages_Asset_AssetList, L("AssetList"));

            var asset_AssetProperty = pages.CreateChildPermission(PermissionNames.Pages_Asset_AssetProperty, L("AssetProperty"));

            var asset_AssetLocation = pages.CreateChildPermission(PermissionNames.Pages_Asset_AssetLocation, L("AssetLocation"));

            var asset_QRCodeManagement = pages.CreateChildPermission(PermissionNames.Pages_Asset_QRCodeManagement, L("QRCodeManagement"));

            var operation = pages.CreateChildPermission(PermissionNames.Pages_Operation, L("Operation1"));

            var operation_ServiceDispatchTxt = pages.CreateChildPermission(PermissionNames.Pages_Operation_ServiceDispatch, L("ServiceDispatchTxt"));

            var security = pages.CreateChildPermission(PermissionNames.Pages_Security, L("Security"));

            var security_CCTV = pages.CreateChildPermission(PermissionNames.Pages_Security_CCTV, L("CCTV"));

            var security_DoorAccess = pages.CreateChildPermission(PermissionNames.Pages_Security_DoorAccess, L("DoorAccess"));

            var energy = pages.CreateChildPermission(PermissionNames.Pages_Energy, L("Energy"));

            var energy_PowerMgr = pages.CreateChildPermission(PermissionNames.Pages_Energy_PowerManagement, L("PowerMgr"));

            var emergency = pages.CreateChildPermission(PermissionNames.Pages_Emergency, L("EmergencyMgr"));

            var emergency_ContingencyPlan = pages.CreateChildPermission(PermissionNames.Pages_Emergency_ContingencyPlan, L("ContingencyPlan"));

            var systemConfig = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig, L("SystemConfig"));

            var systemConfig_Country = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Country, L("Country"));

            var systemConfig_Region = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Region, L("Region"));

            var systemConfig_Province = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Province, L("Province"));

            var systemConfig_City = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_City, L("City"));

            var systemConfig_Location = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Location, L("Location"));

            var systemConfig_SpaceType = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_SpaceType, L("SpaceType"));

            var systemConfig_Organizational = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Organizational, L("Organizational"));

            var systemConfig_CCTV = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_CCTV, L("CCTVConfig"));

            var systemConfig_DoorAccess = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_DoorAccess, L("DoorAccessConfig"));

            var systemConfig_PowerMgr = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_PowerMgr, L("PowerMgrConfig"));

            var systemConfig_UserMgr = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_UserMgr, L("UserMgr"));

            var systemConfig_RoleMgr = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_RoleMgr, L("RoleMgr"));

            var systemConfig_LoginAudit = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_LoginAudit, L("LoginAudit"));

            var systemConfig_UserAudit = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_UserAudit, L("UserAudit"));

            var systemConfig_Version = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Version, L("Version"));

            var systemConfig_Hotline = pages.CreateChildPermission(PermissionNames.Pages_SystemConfig_Hotline, L("Hotline"));

            var userMgr = pages.CreateChildPermission(PermissionNames.Pages_UserMgr, L("UserMgr"));

            var userMgr_Query = pages.CreateChildPermission(PermissionNames.Pages_UserMgr_Query, L("UserMgr_Query"));

            var userMgr_AddUser = pages.CreateChildPermission(PermissionNames.Pages_UserMgr_AddUser, L("UserMgr_AddUser"));

            var propertyMgr = pages.CreateChildPermission(PermissionNames.Pages_PropertyMgr, L("PropertyMgr"));

            var propertyMgr_Query = pages.CreateChildPermission(PermissionNames.Pages_PropertyMgr_Query, L("PropertyMgr_Query"));

            var propertyMgr_AddProperty = pages.CreateChildPermission(PermissionNames.Pages_PropertyMgr_AddProperty, L("PropertyMgr_AddProperty"));

            var propertyMgr_RoomQuery = pages.CreateChildPermission(PermissionNames.Pages_PropertyMgr_RoomQuery, L("PropertyMgr_RoomQuery"));

            var propertyMgr_AddRoom = pages.CreateChildPermission(PermissionNames.Pages_PropertyMgr_AddRoom, L("PropertyMgr_AddRoom"));

            var rentMgr = pages.CreateChildPermission(PermissionNames.Pages_RentMgr, L("RentMgr"));

            var rentMgr_Query = pages.CreateChildPermission(PermissionNames.Pages_RentMgr_Query, L("RentMgr_Query"));

            var rentMgr_Add = pages.CreateChildPermission(PermissionNames.Pages_RentMgr_Add, L("RentMgr_Add"));

            var rentMgr_EarlyWarning = pages.CreateChildPermission(PermissionNames.Pages_RentMgr_EarlyWarning, L("RentMgr_EarlyWarning"));

            var roleMgr = pages.CreateChildPermission(PermissionNames.Pages_RoleMgr, L("RoleMgr"));

            var roleMgr_Query = pages.CreateChildPermission(PermissionNames.Pages_RoleMgr_Query, L("RoleMgr_Query"));

            var roleMgr_AddRole = pages.CreateChildPermission(PermissionNames.Pages_RoleMgr_AddRole, L("RoleMgr_AddRole"));

            var financialStatistics = pages.CreateChildPermission(PermissionNames.Pages_FinancialStatistics, L("FinancialStatistics"));

            var window_Warning = pages.CreateChildPermission(PermissionNames.Pages_Window_Warning, L("Window_Warning"));

            var window_Task = pages.CreateChildPermission(PermissionNames.Pages_Window_Task, L("Window_Task"));

            var window_Financial = pages.CreateChildPermission(PermissionNames.Pages_Window_Financial, L("Window_Financial"));

            var window_Property = pages.CreateChildPermission(PermissionNames.Pages_Window_Property, L("Window_Property"));

            var window_Rent = pages.CreateChildPermission(PermissionNames.Pages_Window_Rent, L("Window_Rent"));

            var window_DataCenter = pages.CreateChildPermission(PermissionNames.Pages_Window_DataCenter, L("Window_DataCenter"));


            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BIMFMConsts.LocalizationSourceName);
        }
    }
}
