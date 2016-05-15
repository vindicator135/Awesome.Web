angular.module("AwesomeWeb").controller("MainAppCtrl", function ($scope, $state, authenticationServices) {
	$state.transitionTo('posts.detail');
});