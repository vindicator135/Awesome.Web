angular.module('AwesomeWeb', ['ui.router', 'ngSanitize', 'ngStorage'
]);

angular.module('AwesomeWeb').constant('config', {
	apiCredentials: 'userName=Stephen Cate&password=Unknown_123&grant_type=password',
	apiBaseUrl: 'http://localhost/AwesomeWeb'
});

function onReady() {
	angular.bootstrap(document, ['AwesomeWeb'], {
		strictDi: true
	});
}