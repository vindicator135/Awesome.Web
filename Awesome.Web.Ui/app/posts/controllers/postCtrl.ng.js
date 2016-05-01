angular.module("AwesomeWeb").controller("PostCtrl", function ($scope, $stateParams, $state, postServices, commentServices) {

	$scope.posts = [];
	$scope.currentPost = {};
	$scope.tags = [{ tagId: 1, name: "Australia" }, { tagId: 2, name: "Migration" }, { tagId: 3, name: "Skilled" }, { tagId: 4, name: "Permanent" }]
	$scope.recentComments = [];
	$scope.searchFilter = '';

	getRecentComments = function () {
		return commentServices.getRecentComments();
	}

	getLatestPost = function (postId) {
		return postServices.getLatestPost();
	}

	getOtherPosts = function () {
		return postServices.getOtherPosts();
	}

	searchPosts = function (query) {
		return postServices.searchPosts(query);
	};

	var init = function () {
		$scope.posts = getOtherPosts();
		$scope.recentComments = getRecentComments();
		$scope.searchPosts = searchPosts;

		if ($stateParams.postId) {
			$scope.currentPost = getLatestPost($stateParams.postId);
		}
		else {
			$scope.currentPost = getLatestPost(null);
		}

		

	};

	init();
	
});