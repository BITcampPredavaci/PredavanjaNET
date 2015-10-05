


(function () {

    var mod = angular.module("postCtrl", ["postService"]);

    mod.controller("PostController", ["PostService", "VoteFactory", function (PostService, VoteFactory) {

        var self = this;
        self.postService = PostService;
        self.vote = vote;


        function vote(isUpvote, index) {
            var vote = new VoteFactory();
            vote.PostId = PostService.postList[index].Id;
            vote.UpVote = isUpvote;
            vote.$save(
                function (response) {
                    PostService.getPost(index);
                }, function (err) {
                    alert(err.data.Message);
                });
        }

    }]);

})();