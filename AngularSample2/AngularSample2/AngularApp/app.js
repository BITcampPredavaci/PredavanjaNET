(function () {




    var app = angular.module("redditApp", ["postCtrl"]);

    app.directive("home", function(){
        return {
            templateUrl: "/AngularApp/templates/index.html",
            controller: "PostController",
            controllerAs: "postCtrl"
        }
    });



})();