angular.module('AwesomeWeb', ['ui.router', 'ngSanitize', 'ngStorage', 'ui.bootstrap']);

angular.module('AwesomeWeb').constant('config', {
	apiCredentials: 'userName=Stephen Cate&password=Unknown_123&grant_type=password',
	apiBaseUrl: 'http://services.ajourneytoawesome.com'
});//http://services.ajourneytoawesome.com,http://localhost/AwesomeWeb

angular.module('AwesomeWeb').run(['$rootScope', '$state', function ($rootScope, $state) {

	$rootScope.$on('$stateChangeStart', function (evt, to, params) {
		if (to.redirectTo) {
			evt.preventDefault();
			$state.go(to.redirectTo, params, { location: 'replace' })
		}
	});
}]);

function onReady() {
	angular.bootstrap(document, ['AwesomeWeb'], {
		strictDi: true
	});
}