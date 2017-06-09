using ImsApi.Entities.Auth;
using ImsApi.Services;
using ImsApi.Contracts.Auth;
using System.Web;
using System;
using System.Web.Http;


namespace ImsApi.Controller.Controllers
{
    
    [RoutePrefix("api/Registration")]
    public class RegistrationController : ApiControllerBase
    {
        private IAuthService _IAuthService;

        public RegistrationController(IAuthService IAuthService)
        {
            _IAuthService = IAuthService;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public bool RegisterUser(RegistrationInputModel registrationInputModel)
        {
            bool Success = false;
           
            var result = _IAuthService.RegisterUser(registrationInputModel);

            //IHttpActionResult errorResult = GetErrorResult(result);

            //if (errorResult != null)
            //{
            //    return errorResult;
            //}

            //return Ok();
            return Success;

        }
    }
}