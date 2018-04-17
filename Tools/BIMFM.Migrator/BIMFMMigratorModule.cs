using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using BIMFM.EntityFramework;

namespace BIMFM.Migrator
{
    [DependsOn(typeof(BIMFMDataModule))]
    public class BIMFMMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<BIMFMDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}