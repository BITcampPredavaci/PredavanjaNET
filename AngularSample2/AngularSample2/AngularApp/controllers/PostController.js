


(function () {

    var mod = angular.module("postCtrl", ["postService"]);

    mod.controller("PostController", ["PostService", function (PostService) {

        var self = this;
        self.postService = PostService;


      

    }]);

})();