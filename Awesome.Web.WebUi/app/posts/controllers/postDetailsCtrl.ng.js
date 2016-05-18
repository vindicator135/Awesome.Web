angular.module("AwesomeWeb").controller("PostDetailsCtrl", function ($scope, $stateParams, $state, postService) {

	var init = function () {

		if ($stateParams.postId) {
			postService.getPostById($stateParams.postId).then(function (data) {
				$scope.currentPost = data
			});
		}
		else {
			postService.getLatestPost().then(function (data) {
				$scope.currentPost = data
			});
		}

	};

	init();
	
});