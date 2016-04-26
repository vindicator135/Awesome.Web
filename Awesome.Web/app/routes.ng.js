/// <reference path="_references.js" />

angular.module("Awesome.Web").config(function ($urlRouterProvider, $stateProvider, $locationProvider) {
	$locationProvider.html5Mode(true);

	$stateProvider
		.state('discussions', {
			url: '/discussions',
			templateUrl: 'app/discussions/views/discussions-list.ng.html',
			controller: 'DiscussionsListCtrl'
		})
		.state('discussionDetails', {
			url: '/discussions/:discussionId',
			templateUrl: 'app/discussions/views/discussion-details.ng.html',
			controller: 'DiscussionDetailsCtrl'
		});

	$urlRouterProvider.otherwise("/discussions");
});