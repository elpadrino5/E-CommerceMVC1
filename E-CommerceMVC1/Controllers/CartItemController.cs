using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceMVC1.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CartItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartItem/Edit/5
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

        // GET: CartItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartItem/Delete/5
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
