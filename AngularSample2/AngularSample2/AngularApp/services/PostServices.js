

(function () {

    var mod = angular.module("postService", ["ngResource"]);

    mod.factory("VoteFactory", ["$resource", function ($resource) {
        return $resource("/api/votes/:id");
    }]);

    mod.factory("PostFactory", ["$resource", function ($resource) {
        return $resource("/api/posts/:id", null,
            {
                "upvote": {
                    method: "post",
                    url: "/api/votes",
                    params: {
                        upVote: true
                    }
                }
            });
    }]);

    mod.service("PostService", ["PostFactory", function (PostFactory) {
        var self = this;
        self.postList = PostFactory.query();
        self.getPost = getPost;

        function getPost(index) {
            var postId = self.postList[index].Id;
            self.postList[index] = PostFactory.get({ Id: postId });
        }

        return self;
    }]);

})();