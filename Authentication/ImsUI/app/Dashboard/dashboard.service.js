(function () {
    'use strict';
    ImsAPP.factory('dashboardService', ['apiCall',function (apiCall) {
        return {
            getOrganization: _getOrganization
           
        };
        /* private functions */
        function _getOrganization(OrgId) {
            debugger;
            var url = 'api/Organization/GetOrgDetail/' + OrgId,
            config = {};
            return apiCall.get(url, config);
        }
    }]);
})();