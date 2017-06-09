(function () {
    'use strict';
    ImsAPP.factory('ordersService', ['$http', function ($http) {

        var serviceBase = 'http://localhost:56555/';
        var ordersServiceFactory = {
            getOrders: _getOrders
        };

        var _getOrders = function () {

            return $http.get(serviceBase + 'api/orders').then(function (results) {
                return results;
            });
        };


        return ordersServiceFactory;

    }]);
})();