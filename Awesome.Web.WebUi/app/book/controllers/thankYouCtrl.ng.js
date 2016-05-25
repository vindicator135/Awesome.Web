angular.module("AwesomeWeb").controller("ThankYouCtrl", function ($scope, $state, $uibModalInstance) {
	
	$scope.ok = function () {
		$uibModalInstance.close();
	};

	$scope.cancel = function () {
		$uibModalInstance.dismiss('cancel');
	};

});