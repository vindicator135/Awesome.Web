angular.module("AwesomeWeb").filter("splitToList", function () {
	return function (list) {
		var tagNames = _.pluck(list, 'Name');
		return tagNames.join();
	}
});