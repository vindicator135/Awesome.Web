angular.module("AwesomeWeb").controller("PostDetailsCtrl", function ($scope, $stateParams, $state, postServices) {

	var init = function () {
		if ($stateParams.postId) {
			$scope.currentPost = postServices.getPostById($stateParams.postId);
		}
		else {
			$scope.currentPost = postServices.getLatestPost();
		}

	};

	init();
	
});