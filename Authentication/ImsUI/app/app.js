﻿var ImsAPP = angular.module('ImsAPP', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ngCookies']);

ImsAPP.config(function ($routeProvider, $httpProvider) {
    $routeProvider.when("/home",{
        controller: "homeController",
        controllerAs: "vm",
    templateUrl:"/app/home/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        controllerAs: "vm",
        templateUrl: "/app/login/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        controllerAs:"vm",
        templateUrl: "/app/signUp/signup.html"
    });

    $routeProvider.when("/dashboard", {
        controller: "dashboardController",
        controllerAs: "vm",
        templateUrl: "/app/Dashboard/orgDetails.html"
    });

    $routeProvider.otherwise({ redirectTo: "/login" });

   // $httpProvider.interceptors.push('authInterceptorService');
});

 //ImsAPP.run(['authService', function (authService) {
 //   debugger;
 //   authService.fillAuthData();
 // }]);