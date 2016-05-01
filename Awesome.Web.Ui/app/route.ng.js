angular.module("AwesomeWeb").config(function ($urlRouterProvider, $stateProvider, $locationProvider) {
	
	$stateProvider
	  .state('posts', {
	  	url: '/posts',
	  	templateUrl: 'app/posts/views/post-main.ng.html',
	  	controller: 'PostCtrl'
	  })
	  .state('posts.detail', {
	  	url: '/{postId}',
	  	templateUrl: 'app/posts/views/post-details.ng.html',
	  	controller: 'PostDetailsCtrl'
	  })
	  .state('posts.search', {
	  	url: '/search/{search}',
	  	templateUrl: 'app/posts/views/search-list.ng.html',
	  	controller: 'SearchPostsCtrl'
	  })
	  .state('posts.tags', {
	  	url: '/tags/{tagId}',
	  	templateUrl: 'app/posts/views/search-list.ng.html',
		controller: 'SearchPostsCtrl'
	  });

	$urlRouterProvider
		.otherwise("/");

	$locationProvider.html5Mode({ enabled: true, requireBase: false });
});