var ImsAPP =  angular.module('ImsAPP', ['ngRoute', 'LocalStorageModule','angular-loading-bar']);

ImsAPP.config(function ($routeProvider, $httpProvider) {
    $routeProvider.when("/home",{
    controller:"homeController",
    templateUrl:"/app/home/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/login/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "indexController",
        templateUrl: "/app/signUp/signup.html"
    });

    //$routeProvider.when("/orders", {
    //    controller: "ordersController",
    //    templateUrl: "/app/orders.html"
    //});

    $routeProvider.otherwise({ redirectTo: "/home" });

    $httpProvider.interceptors.push('authInterceptorService');
});

 //ImsAPP.run(['authService', function (authService) {
 //   debugger;
 //   authService.fillAuthData();
 // }]);