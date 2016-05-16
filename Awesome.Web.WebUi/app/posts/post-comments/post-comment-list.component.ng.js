angular.module("AwesomeWeb").directive("postCommentsList", function (commentService) {

	return {
		restrict: 'E',
		scope: {
			postId: '@'
		},
		templateUrl: 'app/posts/post-comments/post-comment-list.ng.html',
		link: function (scope, elem, attrs) {
			var details = commentService.getCommentsByPostId(scope.postId);
			scope.comments = details.comments;
			scope.title = details.title;
		}
	}
});