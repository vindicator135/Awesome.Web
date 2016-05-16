angular.module("AwesomeWeb").factory("commentService", ['postService', 'httpService', '$log', function (postService, httpService, $log) {
	
	var mockComments = [
		{ PostId: 1, Title: "A journey to awesome", AvatarUrl: "http://placehold.it/300x300", UserName: "Mark Cate", Date: "April 30, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ PostId: 2, Title: "CXZCx !@#!@# asdasdasdasds", AvatarUrl: "http://placehold.it/300x300", UserName: "Maria Kalen Cate", Date: "May 23, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ PostId: 3, Title: "Zqweqweqw qweaszasdas", AvatarUrl: "http://placehold.it/300x300", UserName: "Karen Cate", Date: "June 1, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ PostId: 1, Title: "A journey to awesome", AvatarUrl: "http://placehold.it/300x300", UserName: "Jeffrey Cate", Date: "July 2, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." }
	]

	// TODO: Call http API to get recent comments
	return {
		getRecentComments: function () {
			return mockComments;
		},
		addComment: function (comment) {
			mockComments.push(comment);
		},
		getCommentsByPostId: function (postId) {
			var details = { PostId: postId };

			details.comments =  _.filter(mockComments, function (c) {
				return c.PostId == postId;
			});

			if (details.comments.length > 0) {
				details.Title = details.comments[0].Title;
			}

			return details;
		}
	};

}]);