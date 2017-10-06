using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ImsApi.Entities.Auth;
using ImsApi.Entities.User;
using ImsApi.Services;
using ImsApi.Contracts.Auth;
using System.Threading.Tasks;
namespace ImsApi.Controller.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController :  ApiControllerBase
    {
        private IAuthService _IAuthService;

        public UserController(IAuthService IAuthService):base(IAuthService)
        {
            _IAuthService = IAuthService;
        }

        [HttpPost]
        [Route("GetUser")]
        public async Task<LoggedUser> GetUser(LoggedUserInputModel loggedUserInputModel)
        {
            var LoggedUser = new LoggedUser();
            var UserDTO = await _IAuthService.GetUser(loggedUserInputModel.UserName, loggedUserInputModel.Password);
            if(UserDTO!=null)
            {
                LoggedUser.Email = UserDTO.Email;
                LoggedUser.Name = UserDTO.UserName;
                LoggedUser.OrgId = UserDTO.OrganizationId;
                LoggedUser.Phone = UserDTO.PhoneNumber;
                //LoggedUser.Role = UserDTO.Roles.ToList();
                LoggedUser.UserId = UserDTO.Id;
                LoggedUser.UserClaimList = new List<UserClaim>();
                if(UserDTO.Claims.Count>0)
                {
                    foreach (var claim in UserDTO.Claims)
                    {
                        var UserClaim = new UserClaim();
                        UserClaim.Value = claim.ClaimValue;
                        UserClaim.Type = claim.ClaimType;
                        LoggedUser.UserClaimList.Add(UserClaim);
                    }
                }
                

            }
            return LoggedUser;

        }
    }
}
