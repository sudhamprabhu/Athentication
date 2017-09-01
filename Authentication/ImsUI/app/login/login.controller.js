(function () {
    'use strict';
    ImsAPP.controller('loginController', ['$rootScope', '$location', 'loginService', function ($rootScope, $location, loginService) {
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
            logOut: function () {               
                loginService.removeTokenFromLocalStorage();
                vm.authentication.isAuth = false;
                vm.authentication.userName = "";
                $location.path('/home');
            },
            login: function (loginData) {
                debugger;
                var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
                loginService.getAuthtokens(data).then(function (authtokenDetails) {
                    vm.authentication.isAuth = true;
                    $rootScope.isAuth = true;
                    vm.authentication.userName = loginData.userName;
                    $rootScope.userName = loginData.userName;
                    loginService.setTokenInLocalstorage(authtokenDetails.data);
                    $location.path('/signup');
                }).catch(function (response) {
                    vm.message == 'login failed.';
                    vm.logOut();
                    
                });
            }
        });

    }]);
})();