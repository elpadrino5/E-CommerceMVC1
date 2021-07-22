# Skate Pro Shop
This is a full stack C# ASP.NET MVC e-commerce store that sells skateboards.

**Author:** Angel H. Martinez<br />
**Version:** 1.0.0

## Overview<br />
This project is a web app acting as an online store for selling skateboards.

#### Accounts<br />
Users are required to be logged in to an account to perform any actions on the website except for looking at products. User can register using ASP.NET Authorization. Their email address will be used as identifier for their cart, orders, and checkout info.

#### Shopping<br />
Users can browse through the available items and add them to their carts. When users are ready to purchase the cart items, they can procced to checkout.

#### Payment<br />
Shipping and payment information must be provided at checkout. Users are required to use a fake card info as payment method. This info will be saved to the database and will be used for further purchases. Users have the option to update their shipping and payment info. 

#### Orders<br />
Submitted orders can be access by users. Users can also see the details of their past orders such as list of purchased items.

## Walkthrough<br />

The main page lists all the products. Users can click on a product to go to the details page and click on "Add To Cart" button to add products to their cart.

![1shop](https://user-images.githubusercontent.com/71573442/126697424-4a6f73e5-141d-4d2c-8af7-a2bef3fec6de.png)<br />

From their cart users can remove items and return to main page to continue adding products. When users are ready to checkout their selected items they must click on "Checkout" button. 


![2cart](https://user-images.githubusercontent.com/71573442/126698162-a85ccf4f-74ba-43b6-84c4-a15e6eda68f4.PNG)<br />

Before getting to the checkout page users will be required to fill in shipping and payment info unless they have done it before; in which case their info will be pre-filled. They must use a fake credit card as payment method. Users have the option to edit address and payment info before confirming their purchase.


![3checkout](https://user-images.githubusercontent.com/71573442/126698693-349c2489-4f02-4372-9c74-c6189d1db8a7.png)<br />

After payment is "processed" a record of the order will be created. The order number is randomly generated; this is also the confirmation number.


![4confirmation](https://user-images.githubusercontent.com/71573442/126699112-9bd43e60-166e-4ccd-9dbd-540dd39a7298.PNG)<br />

Users can see all their past orders. Each order has a link to see the details of the orders including purchased items.


![5orders](https://user-images.githubusercontent.com/71573442/126699796-a247ab3c-ab2c-43e0-8231-799f8073866d.png)<br />

The Admin Console allows admins to perform restricted actions on the database such as adding, editing, and deleting products.


![6admin_main](https://user-images.githubusercontent.com/71573442/126714387-d6599e6c-ee18-4cb8-80e9-8b477d6471af.PNG)<br />

![7admin_product](https://user-images.githubusercontent.com/71573442/126714471-77472505-4ccc-49f0-ac6e-9cc39c5de22b.PNG)<br />

 
