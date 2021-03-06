<img alt="Meyer Corporation Logo" src="https://lemon-river-09725971e.azurestaticapps.net/images/Meyer.png" width="400" />

# MeyerCorp.Usps

A more convenient wrapper of the United States Postal Service APIs. 

The USPS Web APIs are an HTTP web service, however they rely on long strings of rudimentary XML as a parameter of the query in the target URL.

MeyerCorp.Usps uses a more traditional RESTful approach in most cases and exposes a Swagger endpoint.

## Architecture

The solution contains five projects:

### [Core](https://github.com/MeyerCorporation/Usps.Core/tree/dev/Core)

This is a .NET Standard library which contains actual translation of the REST inputs to the non-standard input of the USPS API. It also creates a NuGet package which allows the functionality to be included in other .NET applications.

### [ExampleConsole](https://github.com/MeyerCorporation/Usps.Core/tree/dev/ExampleConsole)

This is a .NET Core console application which references the NuGet pagckage and shows how the basic Core library works. It is just a working sample.

### [API](https://github.com/MeyerCorporation/Usps.Core/tree/dev/Api)

This is a .NET Core Web API which allows the product to be configured and hosted like any .NET Core web app.

### [ApiServerless](https://github.com/MeyerCorporation/Usps.Core/tree/dev/ApiServerless)

This is a .NET Core Azure Functions project which allows the product to be hosted as an Azure Functions project.

### [Test](https://github.com/MeyerCorporation/Usps.Core/tree/dev/Test)

This is a collection of unit tests written in xunit.

### Diagram

<img alt="Architecture Diagram" src="https://lucid.app/publicSegments/view/b01bb3ed-97ee-41cf-92b6-24d22a803ce2/image.png" />

## Installation/Application

Use the various projects or just the NuGet package in the following ways:

* Use the Core SDK by importing the NuGet package. This will allow easy use of the USPS API functionality in any .NET Core application.

* Deploy the ApiServerless to an Azure Function project. This will allow SOA for web based projects and any other applications in your organization that can access a RESTful API (i.e. verb-based CRUD and JSON).

* Deploy the Api project to either an Azure hosted AppService or an on-prem or IaaS based IIS server. This will allow you to add various forms of Oauth2 authentication/authorization.

> Do not deploy as a service and allow consumers outside of your organization. If someone else in another organization needs a RESTful service, they can host their own deployment of this repository. After all, if the USPS would simply offer a RESTful-based API, this whole repo could be deprecated!

## Getting Started


### Prerequisites

.NET Core 3.1 or higher.

### Installing

Using Usps.Core depends on your needs:

#### Adding functionality and endpoints to an existing .NET Core Web API project:

Merely install the MeyerCorp.Usps.Api NuGet package to add the controllers to your .NET Core Web project. You will then have the functionality available internally to the application as well as exposing it to your API consumers.
> Keep in mind that consumers will be using your API key. They cannot pass their own at this time, and there are no plans to add this as a feature.

#### Adding functionality to an existing .NET Core project:

Merely install the MeyerCorp.Usps.Core NuGet package to add the functionality to your .NET Core project. You will then have the functionality available internally to the application. Keep in mind that this will be using your one API key. You cannot pass in various keys at this time.

#### Hosting your own Web API:

Simply deploy the Api project to an Azure app service or an IIS server.

#### Hosting serverless in Azure:

Simply deploy the Serverless project to an Azure Functions app.

##### TL;DR

This was originally written to add traditional REST endpoints to any Web API project. However, now I think it's better to host as a Azure Funtions project. This will allow your organization to be able easily access the USPS API w/o the non-traditional stacking of XML structures into the URL of the calls made to the USPS API. Do not expose this to any public users. If they need the functionality, they can go to USPS directly, or host their own service. Remember, this is a wrapper intended to expose the functionality of the USPS API in a more RESTful way.

This repo has sat dormant for some time as my original need disappeared and there was little interest. Recently, I decided to revive it making these significant changes:

**Client project is deprecated.**

The client project was originally a .NET Core SDK which allowed access to an instance of the Web API project. However, it became apparent to me that either you would want to run your own RESTful API to allow other languages and libraries like those used in SPAs. If you were writing in .NET, then just use the Core NuGet package.

**Controllers project is deprecated.**

I originally wrote this with a separate Web API controllers library so that any Web API project could suddenly have the capability of the Web API project itself, but I realized that goes against the grain of microservices and SOA in general.

**Usps project is now the Core project.**

Just a rename.

I don't think any of this will have too much affect on anyone as no one really seems to be using this (including me) but if someone sees a need for this, I believe the updated architecture will be more helpful.

## Running the tests

### Break down into end to end tests

### And coding style tests

## Deployment

## Built With

* [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/)
* [USPS Web API](https://www.usps.com/business/web-tools-apis/welcome.htm)

## Contributing

We are very open to contributions from members of other organizations. Is there some feature or the USPS API that is not implemented here that you need? Let us know and we can set that up or allow you to contribute.

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

## Authors

* **Daniel Przybylski** - [Alfetta159](https://github.com/Alfetta159)

See also the list of [contributors](https://github.com/MeyerCorporation/Usps.Core/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc

## References

* [Welcome to the Web Tools API Portal](https://www.usps.com/business/web-tools-apis/welcome.htm)
* [Azure Functions Quick Start](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio#:~:text=Table%201%20%20%20%20Setting%20%20,created%20function%20can%20be%20triggered%20by%20...%20)
* [.NET Core Web API Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio)
