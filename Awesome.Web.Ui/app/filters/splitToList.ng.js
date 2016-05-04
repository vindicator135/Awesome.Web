angular.module("AwesomeWeb").filter("splitToList", function () {
	return function (list) {
		var tagNames = _.pluck(list, 'name');
		return tagNames.join();
	}
});