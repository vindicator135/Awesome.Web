angular.module("AwesomeWeb").factory("postServices", ['$http', '$log',  function ($http, $log) {
	
	var posts = [];

	var recentPostSample = {
		postId: 1,
		title: "<h2 class='blog-details-headline text-black'>A Couple of Tips When Migrating Abroad</h2>",
		subTitle: "<div class='blog-date no-padding-top'>Posted by <a href='blog-masonry-3columns.html'>Stephen Cate</a> | 02 January 2015 | <a href='blog-masonry-3columns.html'>Migration</a>, <a href='blog-masonry-3columns.html'>Australia</a> </div>",
		subContent: "<div class='blog-details-text'><p class='text-large'>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text</p></div>",
		content: "<div class='blog-details-text'>" +
							"<p class='text-large'>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text</p>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
							"<div class='blog-image margin-eight'><img src='http://placehold.it/1920x1200' alt=''></div>" +
							"<div class='blog-image bg-white'>" +
								"<!-- post details blockquote -->" +
								"<blockquote class='bg-gray'>" +
									"<p>Reading is not only informed by what’s going on with us at that moment, but also governed by how our eyes and brains work to process information. What you see and what you’re experiencing as you read these words is quite different.</p>" +
									"<footer>Jason Santa Maria</footer>" +
								"</blockquote>" +
								"<!-- end post details blockquote -->" +
							"</div>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
						"</div>",
		tags: [{ tagId: 1, name: "Australia" }],
		date: "02 January 2015",
		postAvatarUrl: "http://placehold.it/480x358",
		titleText: "A Couple of Tips When Migrating Abroad"
	};

	var recentPostSample2 = {
		postId: 2,
		title: "<h2 class='blog-details-headline text-black'>CXZCx !@#!@# asdasdasdasds</h2>",
		subTitle: "<div class='blog-date no-padding-top'>Posted by <a href='blog-masonry-3columns.html'>Stephen Cate</a> | 02 January 2015 | <a href='blog-masonry-3columns.html'>Migration</a>, <a href='blog-masonry-3columns.html'>Australia</a> </div>",
		subContent: "<div class='blog-details-text'><p class='text-large'>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text</p></div>",
		content: "<div class='blog-details-text'>" +
							"<p class='text-large'>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text</p>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
							"<div class='blog-image margin-eight'><img src='http://placehold.it/1920x1200' alt=''></div>" +
							"<div class='blog-image bg-white'>" +
								"<!-- post details blockquote -->" +
								"<blockquote class='bg-gray'>" +
									"<p>Reading is not only informed by what’s going on with us at that moment, but also governed by how our eyes and brains work to process information. What you see and what you’re experiencing as you read these words is quite different.</p>" +
									"<footer>Jason Santa Maria</footer>" +
								"</blockquote>" +
								"<!-- end post details blockquote -->" +
							"</div>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
						"</div>",
		tags: [{ tagId: 1, name: "Australia" }, { tagId: 2, name: "Migration" }],
		date: "02 January 2015",
		postAvatarUrl: "http://placehold.it/480x358",
		titleText: "CXZCx !@#!@# asdasdasdasds"
	};

	var recentPostSample3 = {
		postId: 3,
		title: "<h2 class='blog-details-headline text-black'>Zqweqweqw qweaszasdas</h2>",
		subTitle: "<div class='blog-date no-padding-top'>Posted by <a href='blog-masonry-3columns.html'>Stephen Cate</a> | 02 January 2015 | <a href='blog-masonry-3columns.html'>Migration</a>, <a href='blog-masonry-3columns.html'>Australia</a> </div>",
		subContent: "<div class='blog-details-text'><p class='text-large'>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text</p></div>",
		content: "<div class='blog-details-text'>" +
							"<p class='text-large'>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text asd asdf</p>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
							"<div class='blog-image margin-eight'><img src='http://placehold.it/1920x1200' alt=''></div>" +
							"<div class='blog-image bg-white'>" +
								"<!-- post details blockquote -->" +
								"<blockquote class='bg-gray'>" +
									"<p>Reading is not only informed by what’s going on with us at that moment, but also governed by how our eyes and brains work to process information. What you see and what you’re experiencing as you read these words is quite different.</p>" +
									"<footer>Jason Santa Maria</footer>" +
								"</blockquote>" +
								"<!-- end post details blockquote -->" +
							"</div>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
							"<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the standard dummy text.</p>" +
						"</div>",
		tags: [{ tagId: 3, name: "Skilled" }, { tagId: 4, name: "Permanent" }],
		date: "02 January 2015",
		postAvatarUrl: "http://placehold.it/480x358",
		titleText: "Zqweqweqw qweaszasdas"
	};

	posts.push(recentPostSample);
	posts.push(recentPostSample2);
	posts.push(recentPostSample3);

	return {
		searchPosts: function (query) {
			var searchWords = query.split(' ');

			return _.filter(posts, function (p) {
				if (searchWords.length > 0) {
					for (var i = 0; i < searchWords.length ; i++) {
						if (p.content.indexOf(searchWords[i]) > 0)
							return true;
					}
				}
				else {
					return p.content.indexOf(query) > 0;
				}
			});
		},
		getLatestPost: function () {
			// Get the latest post by DATE.. think about using MOMENTS instead
			return recentPostSample;
		},
		getOtherPosts: function () {
			return posts;
		},
		getPostById: function (postId) {
			return _.find(posts, function (p) { return p.postId == postId });
		},
		getPostsByTagId: function (tagId) {
			tagId = parseInt(tagId);
			// TODO: Call http API to get all posts having the same tag
			return _.filter(posts, function (p) { return _.contains(_.pluck(p.tags, 'tagId'), tagId); });
		}
	};

}]);