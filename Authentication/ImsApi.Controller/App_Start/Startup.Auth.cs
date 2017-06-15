using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using AuthBLL.Entities;
using AuthBLL;

namespace ImsApi.Controller
{
    public partial class Startup
    {
       
        public void ConfigureOAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request

            app.CreatePerOwinContext(AuthDbContext.Create);
            app.CreatePerOwinContext<AuthUserManager>(AuthUserManager.Create);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

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

                using (AuthRepository _authRepository = new AuthRepository())
                {
                    var user = await _authRepository.FindUser(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new System.Security.Claims.Claim("sub", context.UserName));
                identity.AddClaim(new System.Security.Claims.Claim("role", "user"));

                context.Validated(identity);

            }
        }
    }
}



// below code is used to single sign in using 


//public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

//public static string PublicClientId { get; private set; }

//public void ConfigureAuth(IAppBuilder app)
//{
//    // Configure the db context and user manager to use a single instance per request
//    app.CreatePerOwinContext(ApplicationDbContext.Create);
//    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

//    // Enable the application to use a cookie to store information for the signed in user
//    // and to use a cookie to temporarily store information about a user logging in with a third party login provider
//    app.UseCookieAuthentication(new CookieAuthenticationOptions());
//    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

//    // Configure the application for OAuth based flow
//    PublicClientId = "self";
//    OAuthOptions = new OAuthAuthorizationServerOptions55561
//    {
//        TokenEndpointPath = new PathString("/Token"),
//        Provider = new ApplicationOAuthProvider(PublicClientId),
//        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
//        AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
//        // In production mode set AllowInsecureHttp = false
//        AllowInsecureHttp = true
//    };


//    // Enable the application to use bearer tokens to authenticate users
//    app.UseOAuthBearerTokens(OAuthOptions);

//    // Uncomment the following lines to enable logging in with third party login providers
//    //app.UseMicrosoftAccountAuthentication(
//    //    clientId: "",
//    //    clientSecret: "");

//    //app.UseTwitterAuthentication(
//    //    consumerKey: "",
//    //    consumerSecret: "");

//    //app.UseFacebookAuthentication(
//    //    appId: "",
//    //    appSecret: "");

//    //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
//    //{
//    //    ClientId = "",
//    //    ClientSecret = ""
//    //});
//}