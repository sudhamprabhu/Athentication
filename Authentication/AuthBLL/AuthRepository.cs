using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using AuthBLL.Entities;
using Microsoft.Owin.Security.OAuth;



namespace AuthBLL
{
  public  class AuthRepository : IDisposable
    {
        private readonly AuthDbContext dbContext;       
        private readonly UserManager<User,long> _authUserManager;
       

        public AuthRepository()
        {

            dbContext = new AuthDbContext();
            var userStore = new UserStore<User,Role,long,Login,UserRole,Claim>(dbContext);
            _authUserManager = new UserManager<User,long>(userStore);
            
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
            dbContext.Dispose();
            _authUserManager.Dispose();

        }

       

    }
}
