(function () {
    'use strict';
    ImsAPP.factory('dashboardService', ['apiCall',function (apiCall) {
        return {
            getOrganization: _getOrganization
           
        };
        /* private functions */
        function _getOrganization(OrgId) {
            debugger;
            var url = 'api/Dashboard/GetOrgDetail/' + OrgId;
            config = {};
            return apiCall.get(url, config);
        }
    }]);
})();