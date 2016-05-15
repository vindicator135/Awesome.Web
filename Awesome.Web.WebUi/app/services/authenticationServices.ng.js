angular.module("AwesomeWeb").factory("authenticationServices", ['$http', '$log', '$sessionStorage', '$q', 'config', function ($http, $log, $sessionStorage, $q, config) {

	return {
		getBearerToken: function () {
			var deferred = $q.defer();

			if ($sessionStorage.accessToken == null || $sessionStorage.eaccessToken == undefined) {
				$http.post(config.apiBaseUrl + '/Token', config.apiCredentials).then(function (response) {
					$sessionStorage.accessToken = response.data.access_token;
					deferred.resolve(response.data.access_token);
				},
				function (response) {
					$log.error(response.data);
					deferred.reject(response.data);
				});
			} else {

				deferred.resolve($sessionStorage.accessToken);
			}

			return deferred.promise;
		}
	};

}]);