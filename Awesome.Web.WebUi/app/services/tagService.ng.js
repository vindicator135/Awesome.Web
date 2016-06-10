angular.module("AwesomeWeb").factory("tagService", ['$log', '$q', 'httpService', function ($log, $q, httpService) {
	

	return {
		getAllTags: function () {
			var deferred = $q.defer();
			// Get the latest post by DATE.. think about using MOMENTS instead
			httpService.get('/api/tags/top/0').then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		},
		addTag: function (tag) {
			var deferred = $q.defer();

			httpService.post('/api/tags', tag).then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		},
		editTag: function (tag) {
			var deferred = $q.defer();

			httpService.put('/api/tags/' + tag.TagId, tag).then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		},
		deleteTag: function (tagId) {
			var deferred = $q.defer();

			httpService.delete('/api/tags/' + tagId).then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		}
	};
}]);
