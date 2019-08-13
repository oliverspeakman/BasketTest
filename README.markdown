The solution consists of 

**CheckServerWeb
an MVC API with a single GET method TotalPrice that calculates the price of the SKU's passed to it.

Here is an example call - 

*http://localhost:44309/api/basket/totalPrice?sku=A99@sku=A99@sku=B15*

**CheckoutClientApp**
a console app that reads in SKUs and calls the API and displays the result

**Checkout.Core**
Containing the BasketService and additionally required services

**Checkout.Core.Tests**
Contains the unit tests to test the BasketService