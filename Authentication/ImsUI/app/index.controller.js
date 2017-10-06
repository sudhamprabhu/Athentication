(function () {
    'use strict';
    function indexController($rootScope, $location, logOutService) {
        var vm = this;       
        $rootScope.userName="";
        $rootScope.isAuth = false;
       
       
        var _savedSuccessfully = true;
        var _message = '';
        
         /* members*/
        angular.extend(this, {           
           
        });
       
         /* functions*/
        angular.extend(this, {
            logOut: function () {
                logOutService.logOut();
            }
        });

    };

    indexController.$inject = [ '$rootScope', '$location','logOutService'];
    angular.module('ImsAPP').controller('indexController', indexController);

})();