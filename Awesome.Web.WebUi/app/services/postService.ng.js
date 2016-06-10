angular.module("AwesomeWeb").factory("postService", ['$log', '$q', 'httpService', function ($log, $q, httpService) {
	return {
		searchPosts: function (query) {
			var deferred = $q.defer();
			// Get the latest post by DATE.. think about using MOMENTS instead
			httpService.get('/api/posts?Search=' + query).then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		},
		getOtherPosts: function () {
			var deferred = $q.defer();

			httpService.get('/api/posts/top/5').then(function (response) {
				deferred.resolve(response.data);
			}, function (response) {
				$log.error(response.statusText);
				deferred.reject(response.data);
			});

			return deferred.promise;
		},
		getLatestPost: function () {
			var deferred = $q.defer();
			// Get the latest post by DATE.. think about using MOMENTS instead
			httpService.get('/api/posts/top/1').then(function (response) {
				if (response.data != null) {
					httpService.get('/api/posts/' + response.data[0].PostId + '/details').then(function (details) {
						deferred.resolve(details.data);
					});
				}
			});

			return deferred.promise;
		},
		getPostById: function (postId) {
			var deferred = $q.defer();
			// Get the latest post by DATE.. think about using MOMENTS instead
			httpService.get('/api/posts/' + postId + '/details').then(function (response) {
				//deferred.resolve(response.data);
				deferred.resolve(response.data);
			}, function (response) {
				$log.error(response.statusText);
				deferred.reject(response.data);
			});

			return deferred.promise;
		},
		getPostsByTagId: function (tagId) {
			var deferred = $q.defer();
			// Get the latest post by DATE.. think about using MOMENTS instead
			httpService.get('/api/posts?Tags=' + tagId).then(function (response) {
				//deferred.resolve(response.data);
				deferred.resolve(response.data);
			}, function (response) {
				$log.error(response.statusText);
				deferred.reject(response.data);
			});

			return deferred.promise;
		},
		addPost: function (post) {
			var deferred = $q.defer();

			httpService.post('/api/posts', post).then(function (response) {
				deferred.resolve(response);
			}, function (response) {
				deferred.reject(response);
			});

			return deferred.promise;
		}
	};
}]);