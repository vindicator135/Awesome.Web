angular.module("AwesomeWeb").factory("httpService", ['$http', '$log', '$q', 'config', 'authService', function ($http, $log, $q, config, authService) {
	
	return {
		post: function (url, data) {
			var deferred = $q.defer();

			authService.getBearerToken().then(function (token) {
				var restConfig = {
					authorization: 'Bearer ' + token
				};

				$http.post(config.apiBaseUrl + url, data, restConfig).then(function (response) {
					deferred.resolve(response);
				}, function (response) {
					$log.error(response);
					deferred.reject(response);
				});

			}, function (response) {
				deferred.reject(response);
			});

			return deferred.promise;
		},
		get: function (url) {
			var deferred = $q.defer();

			authService.getBearerToken().then(function (token) {
				var restConfig = {
					headers: { 'Authorization': 'Bearer ' + token }
				};

				$http.get(config.apiBaseUrl + url, restConfig).then(function (response) {
					deferred.resolve(response);
				}, function (response) {
					$log.error(response);
					deferred.reject(response);
				});

			}, function (response) {
				deferred.reject(response);
			});

			return deferred.promise;
		},
		delete: function (url) {
			var deferred = $q.defer();

			authService.getBearerToken().then(function (token) {
				var restConfig = {
					authorization: 'Bearer ' + token
				};

				$http.delete(config.apiBaseUrl + url, restConfig).then(function (response) {
					deferred.resolve(response);
				}, function (response) {
					$log.error(response);
					deferred.reject(response);
				});

			}, function (response) {
				deferred.reject(response);
			});

			return deferred.promise;
		},
		put: function (url, data) {
			var deferred = $q.defer();

			authService.getBearerToken().then(function (token) {
				var restConfig = {
					authorization: 'Bearer ' + token
				};

				$http.put(config.apiBaseUrl + url, data, restConfig).then(function (response) {
					deferred.resolve(response);
				}, function (response) {
					$log.error(response);
					deferred.reject(response);
				});

			}, function (response) {
				deferred.reject(response);
			});

			return deferred.promise;
		}
	};
}]);