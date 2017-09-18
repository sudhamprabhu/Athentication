

(function () {
    'use strict';
    ImsAPP.factory('registrationService', ['apiCall', function (apiCall) {
        return {
            registerUser: _registerUser
        };
        /* private functions */
        function _registerUser(registration) {
            var url = 'api/Registration/RegisterUser',
            config = {};
            return apiCall.post(url, registration, config);
        }

    }]);

})();