using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using BIMFM.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace BIMFM.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<BIMFM.EntityFramework.BIMFMDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BIMFM";
        }

        protected override void Seed(BIMFM.EntityFramework.BIMFMDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
