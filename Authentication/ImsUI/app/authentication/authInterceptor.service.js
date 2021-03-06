﻿(function () {
    'use strict';
    ImsAPP.factory('authInterceptorService', ['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {

        var authInterceptorServiceFactory = {
            request: _request,
            responseError: _responseError
        };

        return authInterceptorServiceFactory;

         function _request(config) {         
            config = config || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.Authorization = authData.token;
            }

            return config;
        }

         function _responseError(rejection) {
            if (rejection.status === 401) {
                $location.path('/login');
            }
            return $q.reject(rejection);
        }

    }]);
})();