using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using AuthBLL.Entities;

 

namespace AuthBLL
{
  public  class AuthRepository : IDisposable
    {
        private AuthDbContext context;       
        private AuthUserManager _authUserManager;
       
        public AuthRepository(AuthUserManager AuthUserManager)
        {
             
             context = new AuthDbContext();
            _authUserManager = AuthUserManager;


        }

        public async Task<IdentityResult> RegisterUser(string UserName,string Password, string Email)
        {
            
            User user = new User()
            {
                UserName = UserName,
                Email = Email
            };

            var result = await _authUserManager.CreateAsync(user, Password);

            return result;
        }

        public async Task<IdentityUser<long,Login, UserRole, Claim>> FindUser(string userName, string password)
        {
            IdentityUser<long, Login, UserRole, Claim> user = await _authUserManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            context.Dispose();
            _authUserManager.Dispose();

        }

       

    }
}
