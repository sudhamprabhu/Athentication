(function(){
    'use strict';
    ImsAPP.service('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
        debugger;
        var serviceBase = 'http://localhost:56555/';
        var authserviceFactory = {
            //saveRegistration: _saveRegistration,
            //login: _login,
            //logOut: _logOut,
            //fillAuthData: _fillAuthData,
            //authentication:_authentication
        };
       

        var _authentication =  {
            isAuth: false,
            userName: ""
        };

       

        var _saveRegistration=  function(registration) {

            _logOut();

            return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
                return response;
            });
        }

      var _login = function(loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
            var deferred = $q.defer();

            $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;

                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        }

      var  _logOut = function() {

            localStorageService.remove('authorizationData');

            _authentication.isAuth = false;
            _authentication.userName = "";

        }

      var _fillAuthData = function() {
            debugger;
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
            }

        }

        authserviceFactory.authentication = _authentication;
        authserviceFactory.saveRegistration = _saveRegistration,
        authserviceFactory.login =  _login,
        authserviceFactory.logOut=  _logOut,
        authserviceFactory.fillAuthData=  _fillAuthData,
        authserviceFactory.authentication = _authentication
        return authserviceFactory;

    }]);
})();