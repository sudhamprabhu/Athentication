
(function () {
    'use strict';
    ImsAPP.factory('loginService', ['apiCall', 'localStorageService', function (apiCall, localStorageService) {
        return {
            getAuthtokens: _getAuthtokens,
            setTokenInLocalstorage: _setTokenInLocalstorage,
            removeTokenFromLocalStorage: _removeTokenFromLocalStorage
        };
        /* private functions */
        function _getAuthtokens()
        {
            var url = 'token',
            config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
            return apiCall.post(url, data, config);
        }

        function _setTokenInLocalstorage(authtokenDetails)
        {
            localStorageService.set('authorizationData', { token: authtokenDetails.token, userName: authtokenDetails.username });
            
        }

        function _removeTokenFromLocalStorage()
        {
            localStorageService.remove('authorizationData');
        }
    }]);

})();