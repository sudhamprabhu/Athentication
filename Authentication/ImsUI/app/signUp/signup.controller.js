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

        var _registration = { // RegistrationInputModel
                "UserName": null,
                "Password": null,
                "ConfirmPassword": null,
                "Email": null,
                "OrganizationInputModel": { // OrganizationInputModel
                                            "OrganizationId": 0,
                                            "Code": null,
                                            "Name": null,
                                            "Address": null,
                                            "Type": 0,
                                            "PhoneNo": null,
                                            "Country": 0,
                                            "State": 0
                }
            }

        
       var _countries = [
             {
                 id: '1',
                 name: 'India'
             }, {
                 id: '2',
                 name: 'US'
             }];
        var _states = [
             {
                 id: '1',
                 name: 'karnataka'
             }, {
                 id: '2',
                 name: 'Kerala'
             }, {
                 id: '3',
                 name: 'Tamilnadu'
             }, {
                 id: '4',
                 name: 'Maharastra'
             }];

       var _organizationTypes = [{
            id: '1',
            name: 'Agriculture'

        }, {
            id: '2',
            name: 'IT'
        }]
        /* members*/
        angular.extend(this, {
            savedSuccessfully: _savedSuccessfully,
            registration: _registration,
            message: _message,
            countries: _countries,
            states: _states,
            organizationTypes: _organizationTypes
        });

        /* functions*/
        angular.extend(this, {
            signUp: function (registration) {
             
                registrationService.registerUser(registration).then(function (response) {
                   
                        vm.savedSuccessfully = true;
                        vm.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                        //$location.path('/login');
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