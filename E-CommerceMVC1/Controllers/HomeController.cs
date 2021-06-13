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
using DataLibrary1.Models;

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

        public ActionResult AddProduct()
        {
            ViewBag.Message = "Add Product";
            return View();
        }

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

                return RedirectToAction("Index");
            }

            return View();
        }

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

                return RedirectToAction("Index");
            }
            return View();
        }

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

        [HttpPost, ActionName("EraseProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult EraseProductConfirm(int id)
        {
            int submittedItems = DeleteProduct(id);
            return RedirectToAction("Index");
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

                return RedirectToAction("ViewProducts");
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

        public ActionResult AddressForm()
        {
            ViewBag.Message = "Add Address";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressForm(Address_fe model)
        {
            //store email to be pass as id
            string email = User.Identity.Name;

            if (ModelState.IsValid)
            {
                int submittedItems = CreateAddress(
                email,
                model.FirstName,
                model.LastName,
                model.Street,
                model.City,
                model.State,
                model.Zip);

                return RedirectToAction("CheckoutPage");
            }

            return View();
        }

        public ActionResult PaymentForm()
        {
            ViewBag.Message = "Add Address";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentForm(Payment_fe model)
        {
            //store email to be pass as id
            string email = User.Identity.Name;

            if (ModelState.IsValid)
            {
                int submittedItems = CreatePayment(
                email,
                model.NameOnCard,
                model.CardNumber,
                model.Expiration,
                model.CVV
                );

                return RedirectToAction("CheckoutPage");
            }

            return View();
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutPage(Order_fe order)
        {
            //store email to be pass as id
            string email = User.Identity.Name;

            if (ModelState.IsValid)
            {
                int submittedItems = LoadOrder(
                order.ListCartItems,
                order.ItemQty,
                order.Total
                );

                return RedirectToAction("ConfirmationPage");
            }

            return View();
        }

    }
}