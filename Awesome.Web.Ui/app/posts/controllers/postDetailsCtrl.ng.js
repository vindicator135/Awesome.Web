angular.module("AwesomeWeb").controller("PostDetailsCtrl", function ($scope, $stateParams, $state, postServices) {

	var init = function () {
		if ($stateParams.postId) {
			postServices.getPostById($stateParams.postId).then(function (data) { $scope.currentPost = data});
		}
		else {
			postServices.getLatestPost().then(function (data) { $scope.currentPost = data });
		}

	};

	init();
	
});