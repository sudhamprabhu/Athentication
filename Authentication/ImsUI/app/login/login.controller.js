(function () {
    'use strict';
    ImsAPP.controller('loginController', ['$rootScope', '$location', 'loginService', 'logOutService', function ($rootScope, $location, loginService, logOutService) {
        var vm = this;
        
        var _authentication = { isAuth: false, userName: "" };
        var _loginData = { userName: '', password: '' };
        var _message = '';
        /*members*/
        angular.extend(this, {
            authentication: _authentication,
            loginData: _loginData,
            message: _message
        });

        /*functions */
        angular.extend(this, {            
            login: function (loginData) {              
                var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
                loginService.getAuthtokens(data).then(function (authtokenDetails) {                   
                    $rootScope.isAuth = true;                   
                    $rootScope.userName = loginData.userName;
                    debugger;
                    loginService.setTokenInLocalstorage(authtokenDetails.data);
                    debugger;
                    loginService.SetLoggedInUser(loginData.userName, loginData.password);
                    $location.path('/dashboard');
                }).catch(function (response) {
                    logOutService.logOut();
                    loginService.ClearLoggedInUser();
                   // vm.message = response.data.error_description;
                });
            }
        });

    }]);
})();