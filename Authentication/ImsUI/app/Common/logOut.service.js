(function () {
	'use strict';
	ImsAPP.factory('logOutService', ['$rootScope','$location','loginService', function ($rootScope,$location,loginService) {
         
		return {
			logOut: _logOut
		}

		function _logOut()
		{
			loginService.removeTokenFromLocalStorage();
			$rootScope.isAuth = false;
			$rootScope.userName = "";
			$location.path('/login');
        }
	}]);
	
})();