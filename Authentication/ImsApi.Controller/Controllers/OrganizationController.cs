using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ImsApi.Entities.Org;
using ImsApi.Contracts.Org;
using ImsApi.Contracts.Auth;
using System.Web.Http;

namespace ImsApi.Controller.Controllers
{   
    [Authorize]
    [RoutePrefix("api/Organization")]
    public class OrganizationController : ApiControllerBase
    {
        public IOrgService _IOrgService;
        public OrganizationController(IOrgService IOrgService,IAuthService IAuthService):base(IAuthService)
        {
            _IOrgService = IOrgService;
        }

        [HttpGet]
        [Route("GetOrgDetail/{OrgId}")]
        public OrganizationModel  GetOrgDetail(int OrgId)
        {
           return _IOrgService.GetOrgDetail( OrgId);
        }
    }
}
