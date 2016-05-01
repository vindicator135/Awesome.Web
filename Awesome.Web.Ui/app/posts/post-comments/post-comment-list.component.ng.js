angular.module("AwesomeWeb").directive("postCommentsList", function (commentServices) {

	return {
		restrict: 'E',
		scope: {
			postId: '@'
		},
		templateUrl: 'app/posts/post-comments/post-comment-list.ng.html',
		link: function (scope, elem, attrs) {
			scope.comments = commentServices.getCommentsByPostId(scope.postId);
		}
	}
});