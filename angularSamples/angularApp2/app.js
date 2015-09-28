 (function(){	 
	 var app = angular.module("peopleApp", ["sample"]);
	 
	 app.controller("PeopleCtrl", ["$scope", "$http", function($scope, $http){
		 
		 $scope.order = "firstName";
		 $scope.search = "";
		 
		 $scope.person = {};
		 
		 $scope.addContact = function(){
			 if($scope.person.update == null){
				$scope.people.push($scope.person);
			 } 
			$scope.person = {};
		 };
		 
		 $scope.select = function(person){
			$scope.person = person;
			$scope.person.update = true; 
		 };
		 
		 $http
		 .get("./people.json")
		 .then(function(response){
			$scope.people = response.data; 
		 });
		 
	 }]);
	 
	 
 })();