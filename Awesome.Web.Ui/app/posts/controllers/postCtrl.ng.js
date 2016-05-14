angular.module("AwesomeWeb").controller("PostCtrl", function ($scope, $stateParams, $state, postServices, commentServices) {

	$scope.posts = [];
	$scope.currentPost = {};
	$scope.tags = [{ TagId: 1, Name: "Australia" }, { TagId: 2, Name: "Migration" }, { TagId: 3, Name: "Skilled" }, { TagId: 4, Name: "Permanent" }]
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
		getOtherPosts().then(function (data) {
			$scope.posts = data;
		});

		$scope.recentComments = getRecentComments();

		$scope.searchPosts = searchPosts;

		if ($stateParams.postId) {
			getLatestPost($stateParams.postId).then(function (data) {
				$scope.currentPost = data;
			});
		}
		else {
			getLatestPost().then(function (data) {
				$scope.currentPost = data;
			});
		}

		

	};

	init();
	
});