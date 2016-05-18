angular.module("AwesomeWeb").controller("PostCtrl", function ($scope, $stateParams, $state, postService, commentService, tagService) {

	$scope.posts = [];
	$scope.currentPost = {};

	$scope.tags = [{ TagId: 1, Name: "Australia" }, { TagId: 2, Name: "Migration" }, { TagId: 3, Name: "Skilled" }, { TagId: 4, Name: "Permanent" }]
	$scope.recentComments = [];
	$scope.searchFilter = '';

	getRecentComments = function () {
		return commentService.getRecentComments();
	}

	getLatestPost = function (postId) {
		return postService.getLatestPost();
	}

	getOtherPosts = function () {
		return postService.getOtherPosts();
	}

	getTags = function () {
		return tagService.getAllTags();
	}

	searchPosts = function (query) {
		return postService.searchPosts(query);
	};

	var init = function () {
		getOtherPosts().then(function (data) {
			$scope.posts = data;
		});

		getTags().then(function (data) {
			$scope.tags = data;
		});

		getRecentComments().then(function (data) {
			$scope.recentComments = data;
		});

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