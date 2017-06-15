(function () {
    'use strict';
    ImsAPP.controller('indexController', ['$scope', '$location', 'loginService', function ($scope, $location, loginService) {
        var vm = this;
        debugger;
        _variable = null;
        _authentication = { isAuth: false,userName: ""}
        /*members*/
        angular.extend(this, {
            authentication: _authentication
        });

        /*functions */
        angular.extend(this, {
            logOut: function () {
                debugger;
                loginService.removeTokenFromLocalStorage();
                authentication.isAuth = false;
                authentication.userName = "";
                $location.path('/home');
            },
            login: function (loginData) {
                debugger;
                var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
                loginService.getAuthtokens().then(function (authtokenDetails) {
                     authentication.isAuth = true;
                    authentication.userName = authtokenDetails.userName;
                    loginService.setTokenInLocalstorage(authtokenDetails);
                }).catch(function (response) {
                    logOut();
                });
            }
        });
       

       // $scope.authentication = authService.authentication;

    }]);
})();