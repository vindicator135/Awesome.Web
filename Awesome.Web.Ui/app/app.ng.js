angular.module('AwesomeWeb', ['ui.router', 'ngSanitize'
]);

function onReady() {
	angular.bootstrap(document, ['AwesomeWeb'], {
		strictDi: true
	});
}