angular.module("Awesome.Web").factory("DiscussionService", ["$http", "$rootScope", "$location", "Hub", "$timeout", "ConfigSettings",
	function ($http, $rootScope, $location, Hub, $timeout, ConfigSettings) {
    	var Discussions = this;

		// Discussion view model
    	var Discussion = function (discussion) {
    		if (!discussion) discussions = {};

    		var Discussion = {
    			Content: discussion.Content || "Please specify a content"
    		}

    		return Discussion;
    	}

    	// Hub setup
    	var hub = new Hub("discussionHub", {
    		listeners: {
    			'updateRecentDiscussions': function (discussion) {
    				Discussions.addRecentDiscussion(discussion);
    				$rootScope.$apply();
    			}
    		},
    		methods: ['addDiscussion'],
    		errorHandler: function (error) {
				console.error(error)
    		},
    		hubDisconnected: function () {
    			if (hub.connection.lastRrror) {
    				hub.connection.start();
    			}
    		},
    		transpport: 'webSockets',
			logging: true
    	});

    	if (!Discussion.recentDiscussions)
    	{
    		Discussions.recentDiscussions = [];

    		$http({
    			method: 'POST',
    			url: ConfigSettings.API_BASE_URL + '/api/discussion/search',
    			data: { Grouping: 1, Search: '', MaxRecords: 5 }
    		}).then(
				function successCallBack(response) {
					Discussions.recentDiscussions = response.data;
				},
				function errorCallBack(response) {
					console.log('Errors encountered getting Discussions.')
				});
    	}

    	if (!Discussion.allDiscussions) {
    		Discussions.allDiscussions = [];
    	}

    	if (!Discussion.ratedDiscussions) {
    		Discussions.ratedDiscussions = [];
    	}

    	Discussions.addRecentDiscussion = function (discussion) {
    		Discussions.recentDiscussions.push(new Discussion(discussion));
    	}
    	Discussions.send = function (discussion) {
    		hub.addDiscussion(discussion).done(function (result) {
    			console.log(result);
    		});
    	}

    	return Discussions;
    }
]);
