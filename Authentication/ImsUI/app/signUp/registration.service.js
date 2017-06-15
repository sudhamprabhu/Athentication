

(function () {
    'use strict';
    ImsAPP.factory('registrationService', ['apiCall', function (apiCall) {
        return {
            registerUser: _registerUser
        };
        /* private functions */
        function _registerUser() {
            var url = 'api/Registration/RegisterUser',
            config = {};
            return apiCall.post(url, data, config);
        }

    }]);

})();