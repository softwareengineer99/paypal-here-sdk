# PayPal Here SDK (v2.0)
## Introduction
The PayPal Here SDK enables Android, iOS & Windows apps to process in-person credit card transactions using Contactless/EMV chip card readers or mag stripe swipers. PayPal Here SDK library enables you to:
* **Interact with PayPal Hardware** — Detect, connect to, and listen for card events coming from both PayPal provided audio jack based card swipers and Contactless/EMV Chip card readers
* **Process Card-Present payments** — To process the payment using the data coming from card readers (chip card reader or mag stripe card reader) which will be in the encrypted form. 

Developers should use the PayPal Here SDK to get world-class payment process with extremely simple integration.  Some of the main benefits include
* **Low, transparent pricing:** US Merchants pay just 2.7% per transaction (or 3.5% + $0.15 for keyed in transactions), including cards like American Express, with no additional hidden/monthly costs.
* **Safety & Security:** PayPal's solution uses encrypted swipers, such that card data is never made available to merchants or anyone else.
* **Live customer support:** Whenever you need support, we’re available to help with our customer support team.
[Visit our website](https://www.paypal.com/webapps/mpp/credit-card-reader) for more information about PayPal Here.

## Authentication
First you need to complete the on-boarding process and get the access token to use PayPal Here SDK. Without the proper access token, PayPal Here SDK will not get initialized properly and hence first thing is to get the proper access token.

1. Set up a PayPal developer account ([sign up here](https://developer.paypal.com/developer/applications/)) and configure an application to be used with the PayPal Here SDK.  Refer to the [PayPal Here SDK integration Document](https://developer.paypal.com/docs/integration/mobile/pph-sdk-overview/) for information on how to properly configure your app.

2. Deploy and configure the [Retail SDK Authentication Server](https://github.com/djMax/paypal-retail-node) OR manually negotiate the [PayPal oAuth2 flow](https://developer.paypal.com/docs/integration/direct/paypal-oauth2/) to obtain the tokens required for login.

See our [Merchant Onboarding Guide](docs/Merchant%20Onboarding%20Guide.pdf) for suggestions on how to help your merchants sign up for PayPal business accounts and link them in your back-office software.

## Platform specific samples
After completing the on-boarding process and retrieving the `access_token`, continue to the platform specific documentation page for further setup information 
