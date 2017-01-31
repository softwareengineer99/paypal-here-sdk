# PayPal Here SDK for Windows Desktop Apps
This is the sample application and SDK distribution information for PayPal Here Windows Desktop SDK v2.0, which allows you to take card and checkin payments from your mobile application.

## Developer Prerequisites
* Visual Studio 2015 and above
* .Net `v4.5.2` and above
* Add nuget package source http://paypalretailsdknuget.azurewebsites.net/nuget and name it `PayPal`

## Sample App overview
The sample App is organized into multiple pages with each page performing a single SDK action (like `RetailSDK.Initialize()`) chronologically.
The `WpfSampleApp\SDK.Steps\` folder contains the code behind for each of the SDK steps

![soln_explorer](https://cloud.githubusercontent.com/assets/1700689/22450013/a6e9f104-e718-11e6-92a0-2db96c9cc5ab.png)

## Sample App Steps
Following are some of important API's used by the Sample App for taking payments. Refer to the [wiki page](https://github.com/paypal/paypal-here-sdk/wiki) for complete documentation for the SDK.

### 1. SDK Initialization
Invoke the following method to Initialize the SDK. This should be the very first call you make in the SDK
```
RetailSDK.Initialize();
```
The SDK will start discovering connected credit card readers and will try to connect to them after SDK is initialized
### 2. Merchant Initialization
Once you have retrieved a token for your merchant (typically from a backend server), call InitializeMerchant and wait for the task to complete before doing more SDK operations.

```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials("live", "<access-token>"));
```

You need to provide the executing environment (e.g. live, sandbox, stage2d0044, etc.) and the access token for creating the instance `SdkCredentials`. It is highly recommended to provide the information for automatically refreshing an expired access token in one of the following two ways

#### [A] Refresh URL
Provide an endpoint to which the SDK would do a `POST` to retrieve a new `access_token` once the active access token expires
```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials(Stage.Text, AccessToken.Text)
	.SetTokenRefreshCredentials("https://refresh-url"));
```
The endpoint should respond with a valid access token in the `access_token` property of the JSON response body

#### [B] Refresh Token
Provide `refresh_token`, `clientId` & `clientSecret`. SDK will use this information to request a new access token when an existing token expires

```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials(Stage.Text, AccessToken.Text)
	.SetTokenRefreshCredentials(refreshToken: "<refresh-token>", clientId: "<client-id>", clientSecret: "<client-secret>"));
```

When both options are provided, the SDK would chose `[B]` over `[A]`

