
(function () {
    'use strict';
    ImsAPP.factory('loginService', ['apiCall', 'localStorageService','$cookies',  '$rootScope', '$timeout', function (apiCall, localStorageService,$cookies, $rootScope, $timeout) {
        return {
            getAuthtokens: _getAuthtokens,
            setTokenInLocalstorage: _setTokenInLocalstorage,
            removeTokenFromLocalStorage: _removeTokenFromLocalStorage,
            SetLoggedInUser: _SetLoggedInUser,
            ClearLoggedInUser: _ClearLoggedInUser,
            getLoggedUser: _getLoggedUser 
        };
        /* private functions */
        function _getAuthtokens(data)
        {           
            var url = 'token',
            config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            return apiCall.post(url, data, config);
        }

        function _setTokenInLocalstorage(authtokenDetails)
        {
            localStorageService.set('authorizationData', { token: 'Bearer ' + authtokenDetails.access_token});
            // set default auth header for http requests
           // $http.defaults.headers.common['Authorization'] = 'Bearer ' + authtokenDetails.access_token;
        }

        function _removeTokenFromLocalStorage()
        {
            localStorageService.remove('authorizationData');
        }

        function _getLoggedUser(userName, Password) {
           var LoggedUserInputModel = {
                "UserName": userName,
                "Password": Password
            }
            var url = 'api/User/GetUser',
            config = {};
            return apiCall.post(url, LoggedUserInputModel, config);
        }

        function _SetLoggedInUser(userName, Password) {
            debugger;
            _getLoggedUser(userName, Password).then(function (response) {
                $rootScope.globals = {
                    currentUser: response.data
                };
                debugger;
                // store user details in globals cookie that keeps user logged in for 1 week (or until they logout)
                var cookieExp = new Date();
                cookieExp.setDate(cookieExp.getDate() + 7);
                $cookies.putObject('globals', $rootScope.globals, { expires: cookieExp });

                console.log($cookies.get("globals"));
            }).catch(function (error) {
                console.log("Setting Logged User is failed!.");
            });
        }

        function _ClearLoggedInUser() {
            $rootScope.globals = {};
            $cookies.remove('globals');
          //  $http.defaults.headers.common.Authorization = 'Basic';
        }
    }]);

    
})();