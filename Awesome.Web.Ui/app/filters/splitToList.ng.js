angular.module("AwesomeWeb").filter("splitToList", function () {
	return function (list) {
		return list.join();
	}
});