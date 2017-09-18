(function () {
    'use strict';
    function indexController($rootScope, $location, loginService, registrationService) {
        var vm = this;
        $rootScope.userName="";
        $rootScope.isAuth = "";
        $rootScope.isAuth = "";
       
        var _savedSuccessfully = true;
        var _message = '';
        
         /* members*/
        angular.extend(this, {           
           
        });
       
         /* functions*/
        angular.extend(this, {
           
        });

    };

    indexController.$inject = [ '$rootScope', '$location', 'loginService', 'registrationService'];
    angular.module('ImsAPP').controller('indexController', indexController);

})();