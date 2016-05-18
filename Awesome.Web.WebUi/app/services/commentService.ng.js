angular.module("AwesomeWeb").factory("commentService", ['postService', 'httpService', '$log', '$q', function (postService, httpService, $log, $q) {
	
	var mockComments = [
		{ PostId: 1, Title: "A journey to awesome", AvatarUrl: "http://placehold.it/300x300", UserName: "Mark Cate", Date: "April 30, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ PostId: 2, Title: "CXZCx !@#!@# asdasdasdasds", AvatarUrl: "http://placehold.it/300x300", UserName: "Maria Kalen Cate", Date: "May 23, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ PostId: 3, Title: "Zqweqweqw qweaszasdas", AvatarUrl: "http://placehold.it/300x300", UserName: "Karen Cate", Date: "June 1, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." },
		{ PostId: 1, Title: "A journey to awesome", AvatarUrl: "http://placehold.it/300x300", UserName: "Jeffrey Cate", Date: "July 2, 2016", Content: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry." }
	]

	// TODO: Call http API to get recent comments
	return {
		getRecentComments: function () {
			var deferred = $q.defer();

			httpService.get('/api/comments/top/5').then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		},
		addComment: function (comment) {
			var deferred = $q.defer();

			httpService.post('/api/comments', comment).then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		},
		getCommentsByPostId: function (postId) {
			var deferred = $q.defer();

			httpService.get('/api/comments?PostId=' + postId).then(function (response) {
				deferred.resolve(response.data);
			});

			return deferred.promise;
		}
	};

}]);