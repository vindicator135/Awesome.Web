angular.module('AwesomeWeb', ['ui.router', 'ngSanitize', 'ngStorage', 'ui.bootstrap']);

angular.module('AwesomeWeb').constant('config', {
	apiCredentials: 'userName=Stephen Cate&password=Unknown_123&grant_type=password',
	apiBaseUrl: 'http://services.ajourneytoawesome.com'
});//http://services.ajourneytoawesome.com,http://localhost/AwesomeWeb

function onReady() {
	angular.bootstrap(document, ['AwesomeWeb'], {
		strictDi: true
	});
}