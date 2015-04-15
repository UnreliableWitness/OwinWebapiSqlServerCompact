using System.Net.Http.Formatting;
using System.Web.Http;
using Hoebeke.Domain.Repositories;
using Ninject;
using Owin;

namespace Hoebeke.WebApi
{
    // Note: By default all requests go through this OWIN pipeline. Alternatively you can turn this off by adding an appSetting owin:AutomaticAppStartup with value “false”. 
    // With this turned off you can still have OWIN apps listening on specific routes by adding routes in global.asax file using MapOwinPath or MapOwinRoute extensions on RouteTable.Routes
    public class Startup
    {
        public static IKernel Container { get; set; }

        // Invoked once at startup to configure your application.
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("Default", "{controller}/{customerID}", new { controller = "Customer", customerID = RouteParameter.Optional });

            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            // config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            Container = new StandardKernel();
            Container.Bind<ICustomerRepository>().To<CustomerRepository>();

            config.DependencyResolver = new NinjectDependencyResolver(Container);
            builder.UseWebApi(config);

            database is auto constructed, get some migrations going
        }
    }
}
