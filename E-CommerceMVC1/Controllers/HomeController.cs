using E_CommerceMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary1;
using static DataLibrary1.BusinessLogic.ProductProcessor;
using static DataLibrary1.BusinessLogic.CartProcessor;
using static DataLibrary1.BusinessLogic.AddressProcessor;
using static DataLibrary1.BusinessLogic.PaymentProcessor;
using static DataLibrary1.BusinessLogic.OrderProcessor;
using DataLibrary1.Models;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace E_CommerceMVC1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return ViewProducts();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewProducts()
        {
            ViewBag.Message = "Posted products";
            var data = LoadProduct();
            List<Product_fe> products = new List<Product_fe>();

            foreach (var row in data)
            {
                products.Add(new Product_fe
                {
                    ProductId = row.ProductId,
                    Name = row.Name,
                    Price = row.Price,
                    Description = row.Description,
                    ImgUrl = row.ImgUrl,
                });
            }

            return View(products);
        }

        public ActionResult DetailsProduct(int? id)
        {
            ViewBag.Message = $"Detail Product. This is the id: '{id}'.";

            var data = LoadProduct();
            List<Product_fe> products = new List<Product_fe>();

            if (data != null)
            {
                foreach (var row in data)
                {
                    products.Add(new Product_fe
                    {
                        ProductId = row.ProductId,
                        Name = row.Name,
                        Price = row.Price,
                        Description = row.Description,
                        ImgUrl = row.ImgUrl,
                    });
                }
            }
            else
            {
                return ViewProducts();
            }

            return View(products.Where(x => x.ProductId == id).FirstOrDefault());
        }

        [Authorize]
        public ActionResult AddProduct()
        {
            ViewBag.Message = "Add Product";
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product_fe model)
        {
            if (ModelState.IsValid)
            {
                int submittedItems = CreateProduct(
                    //model.ProductId,
                    model.Name,
                    model.Price,
                    model.Description,
                    model.ImgUrl);

                return RedirectToAction("ViewProducts");
            }

            return View();
        }

        [Authorize]
        public ActionResult EditProduct(int? id)
        {
            ViewBag.Message = $"Edit Product. this is the id: '{id}'.";

            var data = LoadProduct();
            List<Product_fe> products = new List<Product_fe>();

            if (data != null)
            {
                foreach (var row in data)
                {
                    products.Add(new Product_fe
                    {
                        ProductId = row.ProductId,
                        Name = row.Name,
                        Price = row.Price,
                        Description = row.Description,
                        ImgUrl = row.ImgUrl,
                    });
                }
            }
            else
            {
                return ViewProducts();
            }

            return View(products.Where(x => x.ProductId == id).FirstOrDefault());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product_fe model)
        {
            if (ModelState.IsValid)
            {
                int submittedItems = UpdateProduct(
                    model.ProductId,
                    model.Name,
                    model.Price,
                    model.Description,
                    model.ImgUrl);

                return RedirectToAction("ProductAdmin");
            }
            return View();
        }

        [Authorize]
        public ActionResult EraseProduct(int? id)
        {
            ViewBag.Message = "Erase Product";

            if (id == null)
            {
                return ViewProducts();
            }

            var data = LoadProduct();
            List<Product_fe> products = new List<Product_fe>();

            foreach (var row in data)
            {
                products.Add(new Product_fe
                {
                    ProductId = row.ProductId,
                    Name = row.Name,
                    Price = row.Price,
                    Description = row.Description,
                    ImgUrl = row.ImgUrl,
                });
            }

            return View(products.Where(x => x.ProductId == id).FirstOrDefault());
        }

        [Authorize]
        [HttpPost, ActionName("EraseProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult EraseProductConfirm(int id)
        {
            int submittedItems = DeleteProduct(id);
            return RedirectToAction("ProductAdmin");
        }

        /// <summary>
        /// cart portion----------------------------------------------------
        /// </summary>

        [Authorize]
        public ActionResult AddToCart(int id)
        {
            Product p = LoadProduct(id);

            try
            {
                int submittedItems = AddItemToCart(
                     User.Identity.Name,
                     p.ProductId,
                     p.Name,
                     p.Price,
                     p.ImgUrl);

                return RedirectToAction("ViewCart");
            }
            catch
            {
                return ViewProducts();
            }
        }

        [Authorize]
        public ActionResult ViewCart()
        {
            //store email to be pass as id
            string email = User.Identity.Name;
            //call function to return cart that match email
            List<CartItem> ci = LoadCart(email);
            //make a list with front end model 
            List<CartItem_fe> ci_fe = new List<CartItem_fe>();

            //loop through each row and assign to fe list
            foreach (var row in ci)
            {
                ci_fe.Add(new CartItem_fe
                {
                    CartItemId = row.CartItemId,
                    ProductId = row.ProductId,
                    ProductName = row.ProductName,
                    Price = row.Price,
                    ImgUrl = row.ImgUrl
                });
            }

            return View(ci_fe);
        }

        //[HttpPost]
        //public ActionResult RemoveCartItem(int id)
        //{
        //    ViewBag.Message = "Remove Cart Item";

        //    return View();
        //}

        //    [HttpPost]
        [Authorize]
        public ActionResult RemoveCartItem(int id)
        {
            ViewBag.Message = "Remove Cart Item";

            //return View();

            if (id > 0)
            {
                int submittedItems = DeleteCartItem(id);
            }

            return RedirectToAction("ViewCart");
        }

        [Authorize]
        public ActionResult AddressForm()
        {
            ViewBag.Message = "Add Address";
            return View();
        }

        [Authorize]
        public ActionResult EditAddressForm(Order_fe model)
        {
            ViewBag.Message = "Edit Address";

            Address_fe address = new Address_fe();

            if (model != null)
            {
                address.FirstName = model.FirstName;
                address.LastName = model.LastName;
                address.Street = model.Street;
                address.State = model.State;                
                address.City = model.City;
                address.Zip = model.Zip;                
            }
            return View(address);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressForm(Address_fe model)
        {
            //store email to be pass as id
            string email = User.Identity.Name;
            //get address info
            var address_data = LoadAddress(email);

            if (ModelState.IsValid)
            {
                if (address_data == null)
                {
                    int submittedItems = CreateAddress(
                    email,
                    model.FirstName,
                    model.LastName,
                    model.Street,
                    model.City,
                    model.State,
                    model.Zip);
                }
                else
                {
                    int submittedItems = UpdateAddress(
                    email,
                    model.FirstName,
                    model.LastName,
                    model.Street,
                    model.City,
                    model.State,
                    model.Zip);
                }
                return RedirectToAction("CheckoutPage");
            }

            return View();
        }

        [Authorize]
        public ActionResult PaymentForm()
        {
            ViewBag.Message = "Add Address";
            return View();
        }

        [Authorize]
        public ActionResult EditPaymentForm(Order_fe model)
        {
            ViewBag.Message = "Edit Payment";

            Payment_fe payment = new Payment_fe();

            if (model != null)
            {
                payment.NameOnCard = model.NameOnCard;
                payment.CardNumber = model.CardNumber;
                payment.CVV = model.CVV;
                payment.Expiration = model.Expiration;
            }
            return View(payment);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentForm(Payment_fe model)
        {
            //store email to be pass as id
            string email = User.Identity.Name;

            //get payment info
            var payment_data = LoadPayment(email);

            if (ModelState.IsValid)
            {
                if (payment_data == null)
                {
                    int submittedItems = CreatePayment(
                    email,
                    model.NameOnCard,
                    model.CardNumber,
                    model.Expiration,
                    model.CVV
                    );
                }
                else 
                {
                    int submittedItems = UpdatePayment(
                    email,
                    model.NameOnCard,
                    model.CardNumber,
                    model.Expiration,
                    model.CVV
                    );
                }
                return RedirectToAction("CheckoutPage");
            }

            return View();
        }

        [Authorize]
        public ActionResult CheckoutPage()
        {
            ViewBag.Message = "Order";

            //store email to be pass as id
            string email = User.Identity.Name;

            //get address info
            var address_data = LoadAddress(email);
            //get payment info
            var payment_data = LoadPayment(email);

            if (address_data == null)
            {
                return RedirectToAction("AddressForm");
            }
            if (payment_data == null)
            {
                return RedirectToAction("PaymentForm");
            }

            //load cart items
            var ci = LoadCart(email);
            //make an order
            Order_fe order = new Order_fe();
            //list of cart items
            List<CartItem_fe> ci_fe = new List<CartItem_fe>();
            //initalise total value of order
            double total = 0;

            //loop through each row and assign to fe list
            foreach (var row in ci)
            {
                ci_fe.Add(new CartItem_fe
                {
                    CartItemId = row.CartItemId,
                    ProductId = row.ProductId,
                    ProductName = row.ProductName,
                    Price = row.Price,
                    ImgUrl = row.ImgUrl
                });
                total += row.Price;
            }

            if (ModelState.IsValid)
            {
                order.ListCartItems = ci_fe;
                order.ItemQty = ci_fe.Count;
                order.Total = total;
                order.FirstName = address_data.FirstName;
                order.LastName = address_data.LastName;
                order.Street = address_data.Street;
                order.City = address_data.City;
                order.State = address_data.State;
                order.Zip = address_data.Zip;
                order.NameOnCard = payment_data.NameOnCard;
                order.CardNumber = payment_data.CardNumber;
                order.Expiration = payment_data.Expiration;
                order.CVV = payment_data.CVV;
            }

            return View(order);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutPage(Order_fe order)
        {
            //store email to be pass as id
            string email = User.Identity.Name;
            //load cart items
            List<CartItem> ci = LoadCart(email);
            //load all existing orders to extract ids and generate id for new order
            List<Order> currentOrders = LoadOrder(email);
            //list to store order ids
            List<int> orderIds = new List<int>();

            //start random number
            var randnum = new Random();
            //var to store generated random number
            int genId = 0;
            //contains number of rows affected
            int submittedItems = 0;

            //if more than one order must make sure generated id is unique
            if (currentOrders.Count > 0)
            {
                //iterate through each order
                foreach (var item in currentOrders)
                {
                    //add to list of existing order ids
                    orderIds.Add(item.OrderId);
                }

                int min = 10000;
                int max = 100000;
                int orderIdsCnt = orderIds.Count;
                //make sure max is at least twice as much as ids already taken
                while (orderIdsCnt > (max / 2))
                {
                    max *= 2;
                }

                do //keep generating a random num until it doesn't match any current order ids
                {
                    //generate rand num from min to max
                    genId = randnum.Next(min, max);
                }
                while (orderIds.Contains(genId));
            }
            else
            {
                genId = randnum.Next(10000, 100000);
            }

            if (ModelState.IsValid)
            {
                submittedItems = CreateOrder(
                genId,
                email,
                order.ItemQty,
                order.Total
                );
            }
            else
            {
                return View();
            }

            if (submittedItems != 1)
            {
                ViewBag.Message("Something went wrong when adding the order");
                return View();
            }

            //make sure order list has at list one item
            if (ci.Count > 0)
            {
                //reset number of submitted items
                submittedItems = 0;

                //iterate through each item in list
                foreach (var row in ci)
                {
                    //add each item to order items table
                    submittedItems += AddItemToOrder(
                    row.ProductId,
                    row.ProductName,
                    row.Price,
                    row.ImgUrl,
                    genId
                    );
                }

                if (submittedItems != ci.Count)
                {
                    ViewBag.Message("There was a problem adding order items to the database");
                    return View();
                }
            }
            else
            {
                ViewBag.Message("There were no items to add to the order");
                return View();
            }
            //if everything went well then redirect with order id parameter of the recently created order
            return RedirectToAction("ConfirmationPage", new { id = genId });
        }

        //public ActionResult ConfirmationPage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ConfirmationPage(int id)
        {
            ViewBag.Message = "Order";

            //get recently created order
            var orderData = LoadOrder(id);
            //load all items for the order
            var orderItemsData = LoadOrderItems(id);
            //declare list of order items
            List<OrderItem_fe> orderItems = new List<OrderItem_fe>();
            //declare object for order model that will be displayed
            var orderPost = new OrderPost_fe();

            //iterate through each item and add to list
            foreach (var row in orderItemsData)
            {
                orderItems.Add(new OrderItem_fe
                {
                    OrderItemId = row.OrderItemId,
                    ProductName = row.ProductName,
                    Price = row.Price,
                    ImgUrl = row.ImgUrl,
                    OrderId = row.OrderId
                });
            }

            if (ModelState.IsValid)
            {
                orderPost.OrderId = orderData.OrderId;
                orderPost.Email = orderData.Email;
                orderPost.ListOrderItems = orderItems;
                orderPost.ItemQty = orderData.ItemQty;
                orderPost.Total = orderData.Total;
            }

            return View(orderPost);
        }

        [Authorize]
        public ActionResult MyOrderPage()
        {
            //store email to be pass as id
            string email = User.Identity.Name;
            //get all existing orders
            var order_data = LoadOrder(email);

            List<OrderPost_fe> orders = new List<OrderPost_fe>();

            foreach (var row in order_data)
            {
                orders.Add(new OrderPost_fe
                {
                    OrderId = row.OrderId,
                    Email = row.Email,
                    ItemQty = row.ItemQty,
                    Total = row.Total,
                });
            }

            return View(orders);
        }

        [Authorize]
        public ActionResult AllOrdersPage()
        {
            //get all existing orders
            var order_data = LoadOrder();

            List<OrderPost_fe> orders = new List<OrderPost_fe>();

            foreach (var row in order_data)
            {
                orders.Add(new OrderPost_fe
                {
                    OrderId = row.OrderId,
                    Email = row.Email,
                    ItemQty = row.ItemQty,
                    Total = row.Total,
                });
            }

            return View(orders);
        }

        [Authorize]
        public ActionResult AdminPage()
        {
            return View();
        }

        [Authorize]
        public ActionResult ProductAdmin()
        {
            ViewBag.Message = "All products";

            //get products from database
            var data = LoadProduct();

            //create list with front end class
            List<Product_fe> products = new List<Product_fe>();

            //iterate over data and add product to list
            foreach (var row in data)
            {
                products.Add(new Product_fe
                {
                    ProductId = row.ProductId,
                    Name = row.Name,
                    Price = row.Price,
                    Description = row.Description,
                    ImgUrl = row.ImgUrl,
                });
            }

            return View(products);
        }
    }
}