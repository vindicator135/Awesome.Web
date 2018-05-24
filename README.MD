# Awesome.Web

## About 
**Awesome.Web** is a blog site that I've built in early 2016 to brush up my web programming chops. This is more of a learning exercise than an enterprise-grade app. Still I think there are some good bits that can be plucked out of the application code. Feel free to re-skin, re-launch, use-and-abuse this base code to suit your needs (no guarantees and warranties of course!). 

## Features
* Stateless-front end using a Bootstrap 3 theme.
* RESTful web service following RESTful API conventions
* Token-based authentication for all RESTful calls
* Online payment support via **PayPal** integration
* Marketing/workflow support via **Send-in-blue** integration
* Data management and persistence using MS SQL with Data Migrations

## Getting Started
Before getting right to it, I'd like to note that to get the most of this code - setting it up and have it running - you would need a level of familiarity with AngularJs, Javascript and C#. That said, let's get right to it.

This repository could be opened in Visual Studio 2015 and above. The solution is composed of three projects:
* Awesome.Web.WebUi
* Awesome.Web.Api
* Awesome.Entities

**Awesome.Web** is a RESTful website and as such, there are two general aspects to it - a **Front-end** and **Back-end**. Here's how the three projects in the solutions are grouped:

### Front-end
#### Awesome.Web.WebUi
_* Tech Used: AngularJs, Javascript, CSS (Boostrap 3), Html *_

### Back-end
#### Awesome.Web.Api
_* Tech used: WebApi, C# *_
#### Awesome.Web.Entities
_* Tech used: EF6, C# *_

## Setting-up and running Awesome.Web

To get the website up and running requires some basic Configuration first of some application settings including hosting in the local environment (aka Local IIS). 

#### Configuration

1. Open the solution file `Awesome.Web.sln`

2. Set the database you will hook up to the website by updating the database details for `DefaultConnection` in following config files -
* *\Awesome.Entities\App.config*
* *\Awesome.Web.Api\Web.config*
* You need to update the connection string in these locations with your DB Server, DB User credential, DB name. The DB name you specify here does NOT need to exist. It will be automatically created with the schema needed in the first API request you'll make.* 
 
3. Set *Awesome.Web.Api* as the start-up project.

4. Configure *Awesome.Web.Api* and *Awesome.Web.WebUi* to run on Local IIS -
* Awesome.Web.Api -> http://localhost/Awesome.Web.Api
* Awesome.Web.WebUi -> http://locallhost/Awesome.Web.WebUi

#### Bootstrapping the Back-end

The project is setup to create the database and all related schema (if it doesn't exists yet). This happens when the first request is received. To send the first request and kick off the backend is straightforward.

1. Run the *Awesome.Web.Api*

2. Using POSTMAN (or a RESTful tool), send a request to create an application user. This will create an account that can be used later to get authentication TOKENs to serve the API calls of the Front-end website:
```javascript
[POST] http://localhost/Awesome.Web.Api/api/Account/Register
{
  {
  "Email": "user@email.com",
  "UserName": "UserName",
  "Password": "User_Password123",
  "ConfirmPassword": "User_Password123"
  }
}
```

#### Launching the Front-end

All front-end code sits on the project *Awesome.Web.WebUi*. There's just a few steps to get it up and running.

1. Update the project-settings in `Awesome.Web.WebUi\app\app.ng.js` for `apiCredentials` and `apiBaseUrl` with the application user created from bootstrapping the back-end, and the configured local IIS site's URL.
```javascript
...
angular.module('AwesomeWeb').constant('config', {
	apiCredentials: 'userName=UserName&password=User_Password123&grant_type=password',
	apiBaseUrl: 'http://localhost/AwesomeWeb'
});
...
```

2. Publish *Awesome.Web.WebUi* into the Local IIS site (i.e. http://localhost/Awesome.Web.WebUi).

3. Browse and see Awesome.Web come to life!




