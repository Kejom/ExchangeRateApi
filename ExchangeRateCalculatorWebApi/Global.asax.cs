using ExchangeRateCalculatorWebApi.Controllers;
using ExchangeRateCalculatorWebApi.CurrencyCalculator;
using ExchangeRateCalculatorWebApi.Logger;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ExchangeRateCalculatorWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IApiManager, NBPApiManager>(Lifestyle.Scoped);
            container.Register<ILogRepository, LogRepository>(Lifestyle.Scoped);
            container.Register<ICurrencyCalc, CurrencyCalc>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
