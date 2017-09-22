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
        private readonly UserManager<UserDTO,long> _authUserManager;
       

        public AuthRepository()
        {

            dbContext = new AuthDbContext();
            var userStore = new UserStore<UserDTO,RoleDTO,long,LoginDTO,UserRoleDTO,ClaimDTO>(dbContext);
            _authUserManager = new UserManager<UserDTO,long>(userStore);
            
        }

        public async Task<IdentityResult> RegisterUser(string UserName,string Password, string Email,int OrganizationId)
        {
            
            UserDTO user = new UserDTO()
            {
               
                UserName = UserName,
                Email = Email,
                OrganizationId= OrganizationId

            };

            var result = await _authUserManager.CreateAsync(user, Password);

            return result;
        }

        public async Task<IdentityUser<long,LoginDTO, UserRoleDTO, ClaimDTO>> FindUser(string userName, string password)
        {
            IdentityUser<long, LoginDTO, UserRoleDTO, ClaimDTO> user = await _authUserManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
             dbContext.Dispose();
            _authUserManager.Dispose();

        }

       

    }
}
