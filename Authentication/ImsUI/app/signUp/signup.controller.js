(function () {
    
    'use strict';
    function signupController($rootScope, $location, loginService, registrationService) {       
        var vm = this;
        $rootScope.userName = "";
        $rootScope.isAuth = "";
        $rootScope.isAuth = "";       
        // $scope.message = "scope message";

        var _savedSuccessfully = true;
        var _message = '';
        var _registration = {
            userName: "",
            password: "",
            confirmPassword: ""
        };

        /* members*/
        angular.extend(this, {
            savedSuccessfully: _savedSuccessfully,
            registration: _registration,
            message: _message
        });

        /* functions*/
        angular.extend(this, {
            signUp: function (registration) {
                debugger;
                registrationService.registerUser(registration).then(function (response) {
                    debugger;
                    console.log("registration : " + response);
                        vm.savedSuccessfully = true;
                        vm.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                        $location.path('/login');
                        //startTimer();

                }).catch(function (response) {
                    vm.savedSuccessfully = true;
                    vm.message = "Oops!. registration failed!";

                });
            }
        });

    };

    signupController.$inject = ['$rootScope', '$location', 'loginService', 'registrationService'];
    angular.module('ImsAPP').controller('signupController', signupController);

})();