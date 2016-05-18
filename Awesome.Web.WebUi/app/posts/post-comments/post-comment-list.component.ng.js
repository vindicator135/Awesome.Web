angular.module("AwesomeWeb").directive("postCommentsList", function (commentService) {

	return {
		restrict: 'E',
		scope: {
			postId: '='
		},
		templateUrl: 'app/posts/post-comments/post-comment-list.ng.html',
		link: function (scope, elem, attrs) {
			scope.comments = [];
			
			scope.$watch('postId', function () {
				if (scope.postId != undefined)
					commentService.getCommentsByPostId(scope.postId).then(function (data) {
						for (var i = 0; i < data.length; i++) {
							scope.comments.push(data[i]);
						}
					});
			});
			
		}
	}
});