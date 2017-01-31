# PayPal Here SDK for Windows Desktop Apps
This is the sample application and SDK distribution information for PayPal Here Windows Desktop SDK v2.0, which allows you to take card and checkin payments from your windows desktop app.

## Developer Prerequisites
* Visual Studio 2015 and above
* .Net `v4.5.2` and above
* Add nuget package source http://paypalretailsdknuget.azurewebsites.net/nuget and name it `PayPal`

## Sample App overview
The sample App is organized into multiple pages with each page performing a single SDK action (like `RetailSDK.Initialize()`).
The `WpfSampleApp/SDK.Steps/` folder contains the code behind for each of the SDK steps

![soln_explorer](https://cloud.githubusercontent.com/assets/1700689/22450013/a6e9f104-e718-11e6-92a0-2db96c9cc5ab.png)

## Sample App Steps
Following are some of important API's used by the Sample App for taking payments. Refer to this [wiki page](https://github.com/paypal/paypal-here-sdk/wiki) for complete documentation for the SDK.

### 1. SDK Initialization
Invoke the following method to Initialize the SDK. This should be the very first call you make in the SDK
```
RetailSDK.Initialize();
```
The SDK will start discovering paired credit card readers and will try to connect to them after SDK is initialized
### 2. Merchant Initialization
Once you have retrieved a token for your merchant (typically from a backend server), call InitializeMerchant and wait for the task to complete before doing more SDK operations.

```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials("live", "<access-token>"));
```

The executing environment (e.g. live, sandbox, stage2d0044, etc.) and the access token are required for initializing the merchant. Although token refresh credentials are optional, it is highly recommended to provide that information. The SDK can automatically refresh an expired access token in one of the following two ways

#### Refresh URL
Provide an endpoint to which the SDK can do a `POST` request to retrieve a new `access_token` once an active access token expires
```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials(Stage.Text, AccessToken.Text)
	.SetTokenRefreshCredentials("https://refresh-url"));
```
The endpoint should respond with a valid access token in the `access_token` property of the JSON response body

#### Refresh Token
Provide `refresh_token`, `clientId` & `clientSecret`. SDK will use this information to request a new access token when an existing token expires

```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials(Stage.Text, AccessToken.Text)
	.SetTokenRefreshCredentials(refreshToken: "<refresh-token>", clientId: "<client-id>", clientSecret: "<client-secret>"));
```

When both options are provided, the SDK would pick Refresh Token over Refresh URL

### 3. Paired Devices
Your App should start listening for connected devices by subscribing to the `DeviceDiscovered` event. These events could be fired anytime after the SDK is initialized

```
RetailSDK.DeviceDiscovered += (sender, device) =>
{
    // A compatible credit card reader was discovered
    Devices.Add(device);
};
```

When the SDK successfully connects to a paired card reader a `Connected` event is emitted on the `PaymentDevice` object
```
RetailSDK.DeviceDiscovered += (sender, device) =>
{
    device.Connected += (pd) => 
    {
    	// Device is connected
    }
    
    device.ConnectionError += (pd, error) => 
    {
    	// Device connection was not successful
    }
    
    device.Disconnected += (pd, error) =>
    {
    	// Device was disconnected
    }
};
```


