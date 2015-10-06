

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

    mod.service("PostService", ["PostFactory", "VoteFactory",
        function (PostFactory, VoteFactory) {
            var self = this;
            self.postList = [];
            self.getPost = getPost;
            self.vote = vote;
            self.hasNext = true;
            self.nextPage = 0;
            self.loadPosts = getPosts;

            getPosts();

            function getPosts() {
                PostFactory.get({ page: self.nextPage },
                    function (result) {
                        console.log(result);
                        self.postList = self.postList.concat(result.Posts);
                        self.hasNext = result.HasNext;
                        self.nextPage = result.NextPage;
                    }, function (err) {
                        self.hasNext = false;
                    });
            }

            function getPost(index) {
                var postId = self.postList[index].Id;
                PostFactory.get({ Id: postId });
            }

            function vote(isUpvote, index) {
                var vote = new VoteFactory();
                vote.PostId = self.postList[index].Id;
                vote.UpVote = isUpvote;
                vote.$save(
                    function (response) {
                        var postId = self.postList[index].Id;
                        PostFactory.get({ Id: postId }, function (response) {
                            self.postList[index] = response;
                        });
                    }, function (err) {
                        alert(err.data.Message);
                    });
            }

            return self;
        }]);

})();