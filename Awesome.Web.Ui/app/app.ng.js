angular.module('AwesomeWeb', ['ui.router', 'ngSanitize', 'ngStorage'
]);

angular.module('AwesomeWeb').constant('config', {
	apiCredentials: 'userName=stephen@cate.com&password=Unknown_123&grant_type=password',
	apiBaseUrl: 'http://localhost:59729'
});

angular.module('AwesomeWeb').run(function (authenticationServices) {
	authenticationServices.setBearerToken();
});

function onReady() {
	angular.bootstrap(document, ['AwesomeWeb'], {
		strictDi: true
	});
}