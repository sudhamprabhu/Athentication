using ImsApi.Entities.Auth;
using System.Threading.Tasks;
using AuthBLL.Entities;
using AuthBLL;
using IMSBLL;
using IMSBLL.Entities;
using ImsApi.Contracts.Auth;
using System.Collections.Generic;

namespace ImsApi.Services
{
    public  class AuthService : ApiServiceBase, IAuthService
    {
        AuthRepository authRepository;
        IMSRepository iMSRepository;
        public AuthService() : base()
        {
            authRepository = new AuthRepository();
            iMSRepository = new IMSRepository();
        }

        public bool GetUser(UserInputModel userInputModel)
        {
            bool success = true;
            var result = authRepository.FindUser(userInputModel.UserName, userInputModel.Password);
            return success;
        }

        public async Task<bool> RegisterUser(RegistrationInputModel registrationInputModel)
        {
            bool success = false;
            UserDTO user = new UserDTO()
            {
                UserName = registrationInputModel.UserName,
                Email = registrationInputModel.Email,
                
            };

            var userDTO = await authRepository.RegisterUser(user, registrationInputModel.Password);
            if(userDTO!=null)
            {
               List<ClaimDTO> claims = new List<ClaimDTO>();
               
               claims.Add(new ClaimDTO() { ClaimType = "Permission", ClaimValue = "ALL" });
               var isClaimSuccess = await  authRepository.AddClaimToUser(userDTO.Id, claims);
               var isRpleSuccess =  await authRepository.AdRoleToUser(userDTO.Id,"Admin");
               
                if(isClaimSuccess&& isRpleSuccess)
                {
                    OrganizationDTO organizationDTO = new OrganizationDTO();
                    organizationDTO.Address = registrationInputModel.OrganizationInputModel.Address;
                    organizationDTO.Code = registrationInputModel.OrganizationInputModel.Code;
                    organizationDTO.Country = registrationInputModel.OrganizationInputModel.Country;
                    organizationDTO.State = registrationInputModel.OrganizationInputModel.State;
                    organizationDTO.Type = registrationInputModel.OrganizationInputModel.Type;
                    organizationDTO.PhoneNo = registrationInputModel.OrganizationInputModel.PhoneNo;
                    organizationDTO.Name = registrationInputModel.OrganizationInputModel.Name;
                    organizationDTO = await SaveOrgDetails(organizationDTO);
                    var result =  await UpdateUser(userDTO);
                    success = true;
                }
            }
            authRepository.Dispose();
            return success;
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            return await authRepository.UpdateUser(user);
        }

        private async Task<OrganizationDTO> SaveOrgDetails(OrganizationDTO organizationDTO)
        {
            return await iMSRepository.SaveOrganizationDetails(organizationDTO);
        }

    }
}
