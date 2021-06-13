using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceMVC1.Models;

namespace E_CommerceMVC1.Controllers
{
    public class CartController : Controller
    {    
        // GET: Cart
        public ActionResult ViewCart()
        {
            return View();
        }
        
        // GET: Cart/Details/5
        public ActionResult ViewCart(int id)
        {
            return View();
        }



        // GET: Cart/Create
        public ActionResult AddToCart()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult AddToCart(Product_fe model)
        {
            try
            {
                // TODO: Add insert logic here
                //AddItem()

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
