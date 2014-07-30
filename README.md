AutoChart SDK Libraries
=======================

This repo contains SDK libraries for working with the REST API of [AutoChart](http://autochart.io) - a real-time customer analytics solution for automotive websites.

## .NET SDK
The AutoChart .NET SDK allows developers to access AutoChart's visitor data through an easy-to-use strongly typed interface.

### Requirements
The SDK was written for .NET v3.5 and above.

### Installation

1. Download the latest build of the AutoChart.Sdk.dll [from here](raw/master/dotnet/dist/AutoChart.Sdk.dll)
2. Add reference to this DLL to your project

### Authenticating
The `VisitorService` class acts as the main interface to the AutoChart API.
In order for it to authenticate with the AutoChart servers, you need to pass the **API Read Key** of your AutoChart account into the constructor, like so:

```csharp
using AutoChart.Sdk;

...

var svc = new VisitorService("rk_012345678901234567890123"); 

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
var svc = new VisitorService("rk_012345678901234567890123");
var visitor = svc.GetVisitorSummary(visitorId);
```

#### By Visitor Email Address
If you don't know the AutoChart VisitorId (e.g. for back-end lead management type web apps), then you can fetch visitor data using a known email address. This method will only work for visitors who have submitted lead enquiries on the website and included their email address as part of their contact info.

```csharp
var email = "test@example.com";
var svc = new VisitorService("rk_012345678901234567890123");
var visitor = svc.GetVisitorSummaryByEmail(email);
```

### Using the Visitor Summary Data in your website/app
Once you've fetched the VisitorSummary data, you can use it however you like simply by accessing the properties on the object.
In order to see what data is available to you, check out the source for the [DataModels.cs](dotnet/AutoChart.Sdk/DataModels.cs) file.