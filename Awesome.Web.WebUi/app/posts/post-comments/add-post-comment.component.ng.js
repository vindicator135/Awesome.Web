angular.module("AwesomeWeb").directive("addPostComment", function (commentServices) {
	return {
		restrict: 'E',
		scope: {
			comments: '=',
			postId: '@',
			title: '@'
		},
		templateUrl: 'app/posts/post-comments/add-post-comment.ng.html',
		link: function (scope, elem, attrs) {

			scope.newComment = { avatarUrl: "http://placehold.it/300x300", date: "April 27, 2016", title: scope.title, postId: scope.postId };

			scope.addNewComment = (comment) => {

				commentServices.addComment(comment);

				scope.comments.push(comment);

				scope.newComment = { avatarUrl: "http://placehold.it/300x300", date: "April 27, 2016", title: scope.title, postId: scope.postId };
			};
		}
	}
});