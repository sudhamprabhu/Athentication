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

        public AuthService(AuthRepository _authRepository) :base(_authRepository)
        {
            authRepository = _authRepository;
        }

        public AuthService():base()
        {
           
        }

        public static AuthUserManager _userManager;


        public bool GetUser(UserInputModel userInputModel)
        {
            bool success = true;
            var result = authRepository.FindUser(userInputModel.UserName, userInputModel.Password);


            return success;
        }

        public bool RegisterUser(RegistrationInputModel registrationInputModel)
        {
            bool success = true;
           
            var result = authRepository.RegisterUser(registrationInputModel.UserName, registrationInputModel.Password, registrationInputModel.Email);


            return success;
        }

        //public  AuthUserManager UserManager
        //{
        //    get
        //    {

        //        return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<AuthUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
    }
}
