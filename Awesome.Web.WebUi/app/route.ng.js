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
	  .state('books', {
	  	url: '/books',
	  	templateUrl: 'app/book/views/book-main.ng.html',
		redirectTo: 'books.makingthebigmove'
	  })
	  .state('books.countdown', {
	  	url: '/comingsoon',
	  	controller: 'ComingSoonCtrl',
	  	templateUrl: 'app/book/views/coming-soon.ng.html'
	  })
	  .state('books.makingthebigmove', {
	  	url: '/making-the-big-move',
	  	controller: 'MainBookCtrl',
	  	templateUrl: 'app/book/views/making-the-big-move.ng.html'
	  })
	  .state('books.thankyou', {
	  	url: '/thankyou',
	  	templateUrl: 'app/book/views/thank-you-purchase.ng.html'
	  })
	;

	$urlRouterProvider
		.otherwise("/");

	$locationProvider.html5Mode({ enabled: true, requireBase: false });
});