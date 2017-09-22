﻿using ImsApi.Entities.Auth;
using Owin;
using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using AuthBLL.Entities;
using AuthBLL;
using Microsoft.AspNet.Identity.EntityFramework;
using ImsApi.Contracts.Auth;

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

        public bool RegisterUser(RegistrationInputModel registrationInputModel)
        {
            bool success = true;
            OrganizationDTO organizationDTO = new OrganizationDTO();
            organizationDTO.Address = registrationInputModel.OrganizationInputModel.Address;
                organizationDTO.Code= registrationInputModel.OrganizationInputModel.Code;
            organizationDTO.Country= registrationInputModel.OrganizationInputModel.Country;
            organizationDTO.State= registrationInputModel.OrganizationInputModel.State;
            organizationDTO.Type= registrationInputModel.OrganizationInputModel.Type;
            organizationDTO.PhoneNo= registrationInputModel.OrganizationInputModel.PhoneNo;
            organizationDTO.Name=registrationInputModel.OrganizationInputModel.Name;
            organizationDTO =  iMSRepository.SaveOrganizationDetails(organizationDTO);

            var result = authRepository.RegisterUser(registrationInputModel.UserName, registrationInputModel.Password, registrationInputModel.Email, organizationDTO.OrganizationId);
            return success;
        }

    }
}
