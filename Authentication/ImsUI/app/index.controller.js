(function () {
    'use strict';
    ImsAPP.controller('indexController', ['$scope', '$rootScope', '$location', 'loginService', 'registrationService', function ($scope,$rootScope, $location, loginService, registrationService) {
        var vm = this
        $rootScope.userName="";
        $rootScope.isAuth = "";
        $rootScope.isAuth = "";

        var _savedSuccessfully = false;
        var _message = "";
        var _registration = {
            userName: "",
            password: "",
            confirmPassword: ""
        };
        angular.extend(this, {
            savedSuccessfully: _savedSuccessfully,
            registration: _registration,
            message: _message
        });
       
        angular.extend(this, {
            signUp: function (registration) {
                debugger;

                //registrationService.registerUser(registration).then(function (response) {

                //        $scope.savedSuccessfully = true;
                //        $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                //        startTimer();

                //    },
                //     function (response) {
                //         var errors = [];
                //         for (var key in response.data.modelState) {
                //             for (var i = 0; i < response.data.modelState[key].length; i++) {
                //                 errors.push(response.data.modelState[key][i]);
                //             }
                //         }
                //         $scope.message = "Failed to register user due to:" + errors.join(' ');
                //     });
            }
        });

    }]);
})();