angular.module("AwesomeWeb").factory("awesomeHttpServices", ['$http', '$log', '$q', 'config', 'authenticationServices', function ($http, $log, $q, config, authenticationServices) {
	
	return {
		post: function (url, data) {
			var deferred = $q.defer();

			authenticationServices.getBearerToken().then(function (token) {
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

			authenticationServices.getBearerToken().then(function (token) {
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
		}
	};
}]);