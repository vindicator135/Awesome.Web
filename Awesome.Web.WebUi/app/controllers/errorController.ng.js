angular.module("AwesomeWeb").controller("ErrorCtrl", function ($scope, $state,  $uibModalInstance) {
	$scope.ok = function () {
		$uibModalInstance.close();
	};

	$scope.cancel = function () {
		$uibModalInstance.dismiss('cancel');
	};
});