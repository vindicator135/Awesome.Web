angular.module("Awesome.Web").controller("DiscussionsListCtrl", ["$scope", "$rootScope", "$state", "DiscussionService",
	function ($scope, $rootScope, $state, DiscussionService) {
		$scope.message = "hello world";

		$scope.discussions = DiscussionService;

		$scope.send = function (content) {
			var d = { Content: content, CreatedBy: 123123123 }

			DiscussionService.send(d);
	}
}]);