using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using AuthBLL.Entities;
using System.Security.Claims;
using System.Collections.Generic;
using AutoMapper;

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
        ~AuthRepository()
        {
            Dispose();
        }

        public async Task<UserDTO> FindById(long UserID)
        {            
          //  var result = await _authUserManager.CreateAsync(user, password);
           // var userDTO = dbContext.Users.Create<UserDTO>();
            var  userDTO =  await _authUserManager.FindByIdAsync(UserID);
            return userDTO;          
        }

        public async Task<UserDTO> RegisterUser(UserDTO user, string password)
        {
            var result = await _authUserManager.CreateAsync(user, password);
            // var userDTO = dbContext.Users.Create<UserDTO>();
            var userDTO = await FindById(user.Id);
            return userDTO;
        }


        public async Task<bool> AddClaimToUser(long UserId,List<ClaimDTO> claims )
        {
            bool isClaimSuccess = false;
            try
            {
                if (claims.Count > 0)
                {
                    foreach (var claimDTO in claims)
                    {
                        var claim = new Claim(claimDTO.ClaimType, claimDTO.ClaimValue);
                        var identityresult = await _authUserManager.AddClaimAsync(UserId, claim);
                        isClaimSuccess = true;
                    }

                }
            }
            catch(Exception ex)
            {
                isClaimSuccess = false;
            }
            return isClaimSuccess;
        }


        public async Task<bool> AdRoleToUser(long UserId, string userRole)
        {
            
           var identityresult = await _authUserManager.AddToRoleAsync(UserId, userRole);          
           return identityresult.Succeeded;
        }
        
        public async Task<UserDTO> FindUser(string userName, string password)
        {
            var userDTO = new UserDTO();
            IdentityUser<long, LoginDTO, UserRoleDTO, ClaimDTO> user = await _authUserManager.FindAsync(userName, password);
            userDTO = Mapper.Map<IdentityUser<long, LoginDTO, UserRoleDTO, ClaimDTO>, UserDTO>(user);
            return userDTO;

        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {

            var identityresult = await _authUserManager.UpdateAsync(userDTO);
            if(identityresult.Succeeded)
            {
                userDTO = await FindById(userDTO.Id);
            }
              
            return userDTO;

        }

        public void Dispose()
        {
             dbContext.Dispose();
            _authUserManager.Dispose();

        }

       

    }
}
