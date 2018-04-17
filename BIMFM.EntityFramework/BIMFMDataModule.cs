using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using BIMFM.EntityFramework;

namespace BIMFM
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(BIMFMCoreModule))]
    public class BIMFMDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BIMFMDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
