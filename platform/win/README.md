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
Once you have retrieved a token for your merchant (typically from a backend server), call `InitializeMerchant` and await task completion before doing further SDK operations.

```
var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials("live", "<access-token>"));
```

The executing environment (e.g. live, sandbox, stage2d0044, etc.) and the access token are required for initializing the merchant. Although token refresh credentials are optional, it is highly recommended to provide it so that the SDK can automatically refresh an expired access token by one of the following ways

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

### 4. Take payment
#### Create Invoice
Before starting a transaction, you first need to build an `Invoice` object by adding at least one cart item and other optional fields like tip, shipping, etc. The currency will default to the merchant's default currency.
```
var invoice = new Invoice(null);
invoice.AddItem("Amount", decimal.One, amount, "", "");
invoice.GratuityAmount = decimal.One; // OPTIONAL
invoice.ShippingAmount = 2; // OPTIONAL
```
#### Activate Card Reader for payment
After building the Invoice object, you can create a new transaction with it and activate the connected card readers to start taking payments.
```
// Provide the UI element which the SDK will use to display modal alerts while payment is in progress
RetailSDK.WpfContentGridForUi = (Grid)Content;

var transaction = RetailSDK.CreateTransaction(invoice);
transaction.Begin(true);
transaction.Completed += (context, error, txRecord) =>
{
    // error - indicates payment failure 
    // txRecord  - will contain the transaction information
};
```


