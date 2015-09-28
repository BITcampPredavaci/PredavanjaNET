(function(){
	
	var mod = angular.module("sample", []);
	
	mod.controller("SampleCtrl", ["$scope", function($scope){
		
		$scope.phone = "123456";
		
	}]);
	
})();