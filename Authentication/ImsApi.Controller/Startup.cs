using Microsoft.Owin;
using Owin;
using System.Web.Http;
using ImsApi.Controller.App_Start;

[assembly: OwinStartup(typeof(ImsApi.Controller.Startup))]

namespace ImsApi.Controller
{

    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AutofacWebapiConfig.Initialize(config);

            ConfigureOAuth(app); // Startup.Auth   

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(config);
        }

    }
}
