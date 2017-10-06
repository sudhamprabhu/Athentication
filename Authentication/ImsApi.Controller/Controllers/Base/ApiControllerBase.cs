using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ImsApi.Contracts.Auth;
using ImsApi.Entities.User;

namespace ImsApi.Controller.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        public IAuthService IAuthService;

        public Lazy<LoggedUser> LoggedUser;

        public  ApiControllerBase(IAuthService _IAuthService)
        {
            IAuthService = _IAuthService;
            LoggedUser = new Lazy<LoggedUser>(GetLoggedUser);
        }

        private LoggedUser GetLoggedUser()
        {
           
            return IAuthService.GetUser(UserId.Value);
             
        }


        public int? UserId
        {
            get
            {
                int? _userId = null;
                int userIdFromRequest;
                var context = GetHttpContext(Request);
                var _identity = context.User.Identity.Name;
                if (int.TryParse(context.User.Identity.Name, out userIdFromRequest))
                    _userId = userIdFromRequest;

                return _userId;


            }
        }
                  

        private static HttpContextWrapper GetHttpContext(HttpRequestMessage Request)
        {
            var contextbase = GetHttpContextBase(Request);
            if (contextbase == null)
                return null;
            return (contextbase as HttpContextWrapper);
        }

        private static HttpContextBase GetHttpContextBase(HttpRequestMessage Request)
        {
            if (Request == null)
                return null;
            object value;
            if (Request.Properties.TryGetValue("MS_HttpContext", out value))
                return null;
            return value as HttpContextBase;
        }

    }
}