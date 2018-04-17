using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace BIMFM
{
    [DependsOn(typeof(BIMFMCoreModule), typeof(AbpAutoMapperModule))]
    public class BIMFMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
