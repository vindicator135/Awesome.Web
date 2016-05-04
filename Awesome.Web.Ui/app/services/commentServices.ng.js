angular.module("AwesomeWeb").factory("commentServices", ['postServices', '$http', '$log', function (postServices, $http, $log) {
	
	var mockComments = [
		{ postId: 1, title: "A journey to awesome", avatarUrl: "http://placehold.it/300x300", userName: "Mark Cate", date: "April 30, 2016", content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ postId: 2, title: "CXZCx !@#!@# asdasdasdasds", avatarUrl: "http://placehold.it/300x300", userName: "Maria Kalen Cate", date: "May 23, 2016", content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ postId: 3, title: "Zqweqweqw qweaszasdas", avatarUrl: "http://placehold.it/300x300", userName: "Karen Cate", date: "June 1, 2016", content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ postId: 1, title: "A journey to awesome", avatarUrl: "http://placehold.it/300x300", userName: "Jeffrey Cate", date: "July 2, 2016", content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." }
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
			var details = { postId: postId };

			details.comments =  _.filter(mockComments, function (c) {
				return c.postId == postId;
			});

			if (details.comments.length > 0) {
				details.title = details.comments[0].title;
			}

			return details;
		}
	};

}]);