using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web;
using AuthBLL.Entities;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using ImsApi.Contracts.Auth;
using ImsApi.Services;
using System;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using ImsApi.Entities.Auth;
using AuthBLL;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;


[assembly: OwinStartup(typeof(ImsApi.Controller.Startup))]

namespace ImsApi.Controller
{


    public  class Startup 
    {
        public static AuthUserManager _userManager;
        private static IAuthService IAuthService;

        public static AuthUserManager UserManager
        {
            get
            {

                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<AuthUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //public Startup(AuthUserManager UserManager)
        //{
        //    _userManager = UserManager;

        //}

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Autofac integration
            var builder = new ContainerBuilder();            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            builder.RegisterWebApiFilterProvider(config);


            ConfigureOAuth(app, _userManager); // Startup.Auth                                                                     // ConfigureAuth(app); // Startup.Auth Existing
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseAutofacMiddleware(container);
            app.UseWebApi(config);
        }


        public bool ConfigureOAuth(IAppBuilder app, AuthUserManager UserManager)
        {
           
            bool success = true;
          //  _userManager = UserManager;
            // app.CreatePerOwinContext(AuthDbContext.Create);
          //  app.CreatePerOwinContext<AuthUserManager>(AuthUserManager.Create);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            return success;
        }

        public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }

            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
               
                AuthRepository AuthRepository = new AuthRepository(_userManager);
                IAuthService = new AuthService(AuthRepository);

                var userInputModel = new UserInputModel()
                {
                    UserName = context.UserName,
                    Password = context.Password
                   
                };
                IAuthService.GetUser(userInputModel);
                //using (AuthRepository _repo = new AuthRepository(_userManager))
                //{
                //    var user = await _repo.FindUser(context.UserName, context.Password);

                //    if (user == null)
                //    {
                //        context.SetError("invalid_grant", "The user name or password is incorrect.");
                //        return;
                //    }
                //}

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new System.Security.Claims.Claim("sub", context.UserName));
                identity.AddClaim(new System.Security.Claims.Claim("role", "user"));

                context.Validated(identity);

            }
        }

       
    }
}
