(function () {
	'use strict';
	ImsAPP.controller('dashboardController', ['$rootScope', '$location', 'dashboardService', 'logOutService', function ($rootScope, $location, dashboardService, logOutService) {
	    var vm = this;
	    debugger;
	   
            dashboardService.getOrganization(1).then(function (OrgDetails) {
                console.log("orgDetails:" + OrgDetails);
                vm.OrgDetails = OrgDetails.data;
            }).catch(function (response) {
                logOutService.logOut();
                // vm.message = response.data.error_description;
            });;
		
	}])
	//function dashboardController($rootScope, $location, dashboardService) { 'dashboardService',
	//	debugger;
	//	var vm = this;
	//	//vm.OrgDetails = dashboardService.getOrganization(1);
	//	//console.log(vm.OrgDetails);
	//}
	
	//dashboardController.$inject = ['$rootScope', '$location', 'dashboardService'];
	//angular.module('ImsAPP').controller('dashboardController', dashboardController);
})();