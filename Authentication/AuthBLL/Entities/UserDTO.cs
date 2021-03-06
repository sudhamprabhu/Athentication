﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthBLL.Entities
{
    
    public class UserDTO : IdentityUser<long, LoginDTO, UserRoleDTO, ClaimDTO>
    {
        #region properties

        public string Hometown { get; set; }

        public int? OrganizationId { get; set; }
        #endregion

        #region methods

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AuthUserManager userManager)
        {
            var userIdentity = await userManager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        #endregion
    }
}
