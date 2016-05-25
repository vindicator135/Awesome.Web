angular.module("AwesomeWeb").controller("ComingSoonCtrl", function ($scope, $stateParams, $state, $uibModal, $log, marketingService) {
	$scope.userEmail;
	$scope.submitted = false;
	$scope.sendCopyToEmail = function () {

		var request = { BookId: 1, Email: $scope.userEmail };

		if ($scope.notifymeform.userEmail.$valid) {

			marketingService.processExcerptRequest(request).then(function (response) {
				var modalInstance = $uibModal.open({
					animation: true,
					templateUrl: 'app/book/views/thank-you.ng.html',
					controller: 'ThankYouCtrl',
					size: 'sm',
				});

				modalInstance.result.then(function (selectedItem) {
					$state.transitionTo('posts.detail');
				}, function () {
					$log.info('Modal dismissed at: ' + new Date());
				});
			});
		}
		else {
			$scope.submitted = true;
		}
			 
		
	};


});