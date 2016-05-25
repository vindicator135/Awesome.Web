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
	  })
	  .state('book', {
	  	url: '/book',
	  	templateUrl: 'app/book/views/book-main.ng.html'})
	  .state('book.countdown', {
	  	url: '/comingsoon',
	  	controller: 'ComingSoonCtrl',
	  	templateUrl: 'app/book/views/coming-soon.ng.html'
	  })
	;

	$urlRouterProvider
		.otherwise("/");

	$locationProvider.html5Mode({ enabled: true, requireBase: false });
});