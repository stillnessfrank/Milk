using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using BIMFM.Roles;

namespace BIMFM.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(BIMFMApplicationModule))]
    public class BIMFMWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(BIMFMApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
