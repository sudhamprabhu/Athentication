using ImsApi.Entities.Auth;
using ImsApi.Services;
using ImsApi.Contracts.Auth;
using System.Web;
using System;
using System.Web.Http;
using System.Threading.Tasks;
using ImsApi.Contracts.Org;


namespace ImsApi.Controller.Controllers
{
    
    [RoutePrefix("api/Registration")]
    public class RegistrationController : ApiControllerBase
    {
        private IAuthService _IAuthService;

        public RegistrationController(IAuthService IAuthService):base(IAuthService)
        {
            _IAuthService = IAuthService;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<bool> RegisterUser(RegistrationInputModel registrationInputModel)
        {
            bool Success = false;

            Success = await _IAuthService.RegisterUser(registrationInputModel);

            return Success;

        }
    }
}