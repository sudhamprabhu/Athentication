using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using AuthBLL.Entities;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;


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

        public async Task<UserDTO> RegisterUser(UserDTO user,string password)
        {            
            var result =  _authUserManager.CreateAsync(user, password).Result;
            var userDTO = dbContext.Users.Create<UserDTO>();
            if (result.Succeeded)
            {
                userDTO =  _authUserManager.FindAsync(userDTO.UserName, password).Result ?? new UserDTO();
            }

            return  userDTO;          
        }

        public async Task<bool> AddClaimToUser(long UserId)
        {
            var identityresult = await _authUserManager.AddClaimAsync(UserId, new Claim("Permission", "ALL"));
            return identityresult.Succeeded;
        }


        public async Task<bool> AdRoleToUser(long UserId)
        {
            var identityresult = await _authUserManager.AddToRoleAsync(UserId, "Admin");
            return identityresult.Succeeded;
        }
        //identityresult.
        //   await _authUserManager.AddToRoleAsync(User.Id, "Admin");

        public async Task<IdentityUser<long,LoginDTO, UserRoleDTO, ClaimDTO>> FindUser(string userName, string password)
        {

            IdentityUser<long, LoginDTO, UserRoleDTO, ClaimDTO> user = await _authUserManager.FindAsync(userName, password);

            //var userRole = await _authUserManager.FindByIdAsync(User.GetUserId());

            //// var user = await _authUserManager.FindByIdAsync(User.GetUserId());

           // var adminRole = await _authUserManager.FindByNameAsync("Admin");
            //if (adminRole == null)
            //{
            //    adminRole = new IdentityRole("Admin");
            //    await _authUserManager.CreateAsync(adminRole);

             //  await _authUserManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "projects.view"));
            //    await _authUserManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "projects.create"));
            //    await _authUserManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "projects.update"));
            //}

            //if (!await _authUserManager.IsInRoleAsync(user, adminRole.Name))
            //{
            //    await _authUserManager.AddToRoleAsync(user, adminRole.Name);
            //}

            //var accountManagerRole = await _authUserManager.FindByNameAsync("Account Manager");

            //if (accountManagerRole == null)
            //{
            //    accountManagerRole = new IdentityRole("Account Manager");
            //    await _authUserManager.CreateAsync(accountManagerRole);

            //    await _authUserManager.AddClaimAsync(accountManagerRole, new Claim(CustomClaimTypes.Permission, "account.manage"));
            //}

            //if (!await _authUserManager.IsInRoleAsync(user, accountManagerRole.Name))
            //{
            //    await _authUserManager.AddToRoleAsync(user, accountManagerRole.Name);
            //}
            return user;

        }

        public void Dispose()
        {
             dbContext.Dispose();
            _authUserManager.Dispose();

        }

       

    }
}
