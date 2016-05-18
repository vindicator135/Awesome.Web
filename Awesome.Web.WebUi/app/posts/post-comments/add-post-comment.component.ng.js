angular.module("AwesomeWeb").directive("addPostComment", function (commentService) {
	return {
		restrict: 'E',
		scope: {
			comments: '=',
			postId: '='
		},
		templateUrl: 'app/posts/post-comments/add-post-comment.ng.html',
		link: function (scope, elem, attrs) {

			scope.newComment = { AvatarUrl: "http://placehold.it/300x300", PostId: scope.postId, CreatedBy: 'Stephen Cate' };

			scope.addNewComment = (comment) => {
				comment.PostId = scope.postId;
				comment.CreatedByName = comment.UserName;
				comment.DisplayCreated = moment().format('MMMM Do YYYY, h:mm:ss a');
				commentService.addComment(comment);
				scope.comments.push(comment);

				scope.newComment = { AvatarUrl: "http://placehold.it/300x300", PostId: scope.postId, CreatedBy: 'Stephen Cate' };
			};
		}
	}
});