# AutoChart .NET SDK

The [AutoChart](http://autochart.io) .NET SDK allows developers to access AutoChart's visitor data through an easy-to-use strongly typed interface. Under the hood, the library talks to AutoChart's REST API over HTTPS.
Currently it only supports reading data back from AutoChart. If you want to send tracking data _to_ AutoChart, use the [JavaScript API](https://github.com/AutoChart/autochart-js).

## Requirements
The SDK was written for .NET v3.5 and above.

## Installation via Nuget
To install AutoChart.Sdk, run the following command in the Package Manager Console.
`
Install-Package AutoChart.Sdk
`
This will add a reference to the AutoChart.Sdk.dll and its dependencies to your Visual Studio project.

## Usage
### Authenticating
The `VisitorService` class acts as the main interface to the AutoChart API.
In order for it to authenticate with the AutoChart servers, you need to pass the **API Read Key** of your AutoChart account into the constructor, like so:

```csharp
using AutoChart.Sdk;

...

var svc = new VisitorService("rk_30946e70413f40a7a38f875f1717b1d5"); 

``` 

You can access this key in the Account Settings page of the [AutoChart portal](https://portal.autochart.io).

### Identifying the current visitor in the website
The [AutoChart JavaScript tracking library](http://autochart.io/docs) generates a unique VisitorId for each visitor on your website. 
It stores this VisitorId inside a long-life cookie in the client's browser.
In order to access this VisitorId on the server-side of your ASP.NET website, you can use the AutoChartHttpContext class, which will handle the cookie parsing for you. For example:
```csharp
var visitorId = AutoChartHttpContext.Current().VisitorId;
```

### Fetching Visitor Summary Data
#### By Visitor ID
If you already know the AutoChart VisitorId, then you can fetch the visitor data from AutoChart servers through the `GetVisitorSummary` method which returns a `VisitorSummary` object.
```csharp
var visitorId = "53eb6f208074fd5c417b1620";
var svc = new VisitorService("rk_30946e70413f40a7a38f875f1717b1d5");
var visitor = svc.GetVisitorSummary(visitorId);
```

#### By Visitor Email Address
If you don't know the AutoChart VisitorId (e.g. for back-end lead management type web apps), then you can fetch visitor data using a known email address. This method will only work for visitors who have submitted lead enquiries on the website and included their email address as part of their contact info.

```csharp
var email = "lizziehaynes@zisis.com";
var svc = new VisitorService("rk_30946e70413f40a7a38f875f1717b1d5");
var matchingVisitors = svc.GetVisitorsByEmail(email);
```

### Using the Visitor Summary Data in your website/app
Once you've fetched the VisitorSummary data, you can use it however you like simply by accessing the properties on the object.
In order to see what data is available to you, check out the source for the [DataModels.cs](dotnet/AutoChart.Sdk/DataModels.cs) file.