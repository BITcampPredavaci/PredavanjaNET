(function(){
	
	var app = angular.module("sampleApp", []);
	
	/*angular.module("sampleApp", [])
	.controller()*/
	
	app.controller("MainCtrl", ["$scope", function($scope){
		$scope.name = "Projektor";
		$scope.time = 60;
		
		$scope.reset = function(){
			$scope.name = "Projektor";
		};
		
		setInterval(function(){
			$scope.time -= 1;
			$scope.$apply();
		}, 1000);
	}]);
	
	app.controller("HomeCtrl", [function(){
		this.title = "My Title";
	}]);
	
	app.controller("ChildCtrl", ["$scope", function($scope){
		$scope.setName = function(){
			$scope.name = "Set from child";	
		};
	}]);
	
})();