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

## Running Awesome.Web

1. Open the solution file `Awesome.Web.sln`
2. Set the solution to start-up on the following projects:
* Awesome.Web.Api
* Awesome.Web.WebUi
3. Set the database you will hook up to the website by updating the database details for `DefaultConnection` in following config files -
* \Awesome.Entities\App.config
* \Awesome.Web.Api\Web.config
4. Configure *Awesome.Web.Api* and *Awesome.Web.WebUi* to run on the Local IIS -
For example say -
* Awesome.Web.Api -> http://localhost/Awesome.Web.Api
* Awesome.Web.WebUi -> http://locallhost/Awesome.Web.WebUi
5. Build and run the solution.




