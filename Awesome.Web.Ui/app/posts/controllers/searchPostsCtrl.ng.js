angular.module("AwesomeWeb").controller("SearchPostsCtrl", function ($scope, $stateParams, postServices) {

	getPostsByTagId = function (tagId) {
		return postServices.getPostsByTagId(tagId);
	}

	getPostsByQuery = function (query) {
		return postServices.searchPosts(query);
	}

	var init = function () {

		if ($stateParams.tagId) {
			$scope.posts = getPostsByTagId($stateParams.tagId);
		}
		else if ($stateParams.search) {
			$scope.posts = getPostsByQuery($stateParams.search);
		}

	};

	init();
	
});