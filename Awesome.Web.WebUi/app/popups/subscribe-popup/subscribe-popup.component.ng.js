angular.module("AwesomeWeb").directive("subscribePopup", function ($timeout, $uibModal, $state, $log, marketingService) {
	return {
		restrict: 'E',
		scope: {
			waitInterval : "="
		},
		link: function (scope, elem, attrs) {

			if (!scope.waitInterval) {
				scope.waitInterval = 7000;
			}
			// Show the 'Subscribe' modal after 15 seconds
			$timeout(showPopup, scope.waitInterval, true, $uibModal, $state, $log);

			function showPopup(modalService, stateService, logService) {
				var modalInstance = modalService.open({
					animation: true,
					templateUrl: 'app/popups/subscribe-popup/subscribe-popup.ng.html',
					size: 'md',
				});
			}
		}
	}
});