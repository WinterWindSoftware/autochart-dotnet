autochart-sdk
=============

SDK libraries for working with AutoChart's REST APIs

## .NET SDK
The AutoChart .NET SDK allows developers to access AutoChart's visitor data through an easy-to-use strongly typed interface.

### Installing the SDK

1. Download the built AutoChart.Sdk.dll (TODO: add URL of build DLL)
2. Add reference to this DLL to your project

### Using the SDK
#### Authenticating
You need to pass the **API Read Key** of your AutoChart account in order to be able to authenticate with the AutoChart servers, like so:

` var svc = new VisitorService("rk_012345678901234567890123");

You can access this key in the Account Settings page of the [AutoChart portal](https://portal.autochart.io).

#### Identifying the current visitor in the website
TODO

#### Fetching Visitor Data
##### By Visitor ID
TODO

##### By Visitor Email Address
TODO
