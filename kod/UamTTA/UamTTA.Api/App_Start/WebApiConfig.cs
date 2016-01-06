using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using UamTTA.Services;
using UamTTA.Storage;

namespace UamTTA.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            ConfigureContainer(builder);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            EnableCrossSiteRequests(config);
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(_ => new UamTTAContext("UamTTAConnectionString")).As<UamTTAContext>();
            builder.RegisterType<BudgetFactory>().As<IBudgetFactory>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<BudgetService>().As<IBudgetService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
        }

        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*");
            config.EnableCors(cors);
        }
    }
}