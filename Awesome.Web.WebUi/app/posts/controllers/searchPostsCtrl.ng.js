angular.module("AwesomeWeb").controller("SearchPostsCtrl", function ($scope, $stateParams, postService) {
	getPostsByTagId = function (tagId) {
		return postService.getPostsByTagId(tagId);
	}

	getPostsByQuery = function (query) {
		return postService.searchPosts(query);
	}

	var init = function () {
		if ($stateParams.tagId) {
			getPostsByTagId($stateParams.tagId).then(function (data) { $scope.posts = data; });
		}
		else if ($stateParams.search) {
			getPostsByQuery($stateParams.search).then(function (data) { $scope.posts = data; });
		}
	};

	init();
});