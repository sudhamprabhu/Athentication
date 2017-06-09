﻿using Owin;
using ImsApi.Entities.Auth;
using AuthBLL.Entities;

namespace ImsApi.Contracts.Auth
{
   public interface IAuthService
    {
        bool RegisterUser(RegistrationInputModel registrationInputModel);

        bool GetUser(UserInputModel userInputModel);

    }
}