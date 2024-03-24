using Autofac;
using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core.UnitOfWork;
using Customer_Tracking_System.Repository.Repositories;
using Customer_Tracking_System.Repository.UnitOfWorks;
using Customer_Tracking_System.Repository;
using Customer_Tracking_System.Service.Mapping;
using Customer_Tracking_System.Service.Services;
using System.Reflection;
using Customer_Tracking_System.Core.Services;

namespace Customer_Tracking_System.API.Modules
{
    public class RepoServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();




            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            // builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

        }
    }
}
