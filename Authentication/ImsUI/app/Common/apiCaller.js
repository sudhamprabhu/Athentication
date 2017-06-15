(function () {
    'use strict';
    ImsAPP.factory('apiCall', ['$http', '$q', '$location', function ($http, $q, $location) {
        var serviceBase = 'http://localhost:57789/';
        function processRequest(verb, uri, payload, config) {
            debugger;
            var differed = $q.defer();
            var headerOptions = {
                "Accept": "text/json",
                "Content-Type": "application/json; charset=utf-8"
            };

            if (config.headers)
            {
                headerOptions = config.headers;
            }
            var xhr = $http({
                method: verb,
                url: serviceBase+uri,
                data:(payload!==null)?payload:null,
                headers: headerOptions || {} 
            }).then(function (response) {
                debugger;
                differed.resolve(response);
            },
           function (response) { 
                differed.reject(response);
          });
            return differed.promise;            
        };

        return {
            get: function (uri, config) {
                return processRequest('get',uri,null, config);
            },
            post: function (uri,data, config) {
                return processRequest('post', uri, data, config);
            }           
        };

    }]);

})();