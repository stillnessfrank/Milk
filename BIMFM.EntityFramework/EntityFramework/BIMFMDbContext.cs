using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Zero.EntityFramework;
using BIMFM.Authorization.Roles;
using BIMFM.Entities;
using BIMFM.MultiTenancy;
using BIMFM.Users;
using EntityFramework.DynamicFilters;

namespace BIMFM.EntityFramework
{
    public class BIMFMDbContext : AbpZeroDbContext<Tenant, Role, User>, ITransientDependency
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Property> Properties { get; set; }
        public virtual IDbSet<PropertyInfo> PropertyInfoes { get; set; }
        public virtual IDbSet<ContractInfo> ContractInfoes { get; set; }
        public virtual IDbSet<Room> Rooms { get; set; }


        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public BIMFMDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in BIMFMDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of BIMFMDbContext since ABP automatically handles it.
         */
        public BIMFMDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public BIMFMDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public BIMFMDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BIMFMDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

    }
}
