angular.module("AwesomeWeb").controller("MainAppCtrl", function ($scope, $state) {
	$state.transitionTo('posts.detail');
});