angular.module("AwesomeWeb").factory("marketingService", ['httpService', '$log', '$q','$uibModal','config', function (httpService, $log, $q, $uibModal, config) {

	return {
		processExcerptRequest: function (request) {
			var deferred = $q.defer();

			httpService.post('/api/marketing/newexcerptrequest', request).then(function (response) {
				deferred.resolve(response);
			}, function (response) {
				var modalInstance = $uibModal.open({
					animation: true,
					templateUrl: 'app/views/errors.ng.html',
					controller: 'ErrorCtrl',
					size: 'sm',
				});
			});

			return deferred.promise;

		}
	};

}]);