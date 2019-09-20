using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cremas.Controllers
{
    public class ProductController : Controller
    {
        public static List<Models.Product> ListProduct = new List<Models.Product> {
                new Models.Product {
                    id = 1,
                    name = "Producto uno",
                },
                new Models.Product {
                    id = 2,
                    name = "Producto dos",
                },
                new Models.Product {
                    id = 3,
                    name = "Producto tres",
                }

            };

        // GET: Product
        public ActionResult Index()
        {
            var products = from product in GetProducts()
                           orderby product.id
                           select product;

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            List<Models.Product> products = GetProducts();
            var product = products.Single(item => item.id == id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            List<Models.Product> products = GetProducts();
            var product = products.Single(item => item.id == id);

            try
            {

                if (TryUpdateModel(product)) {
                    return RedirectToAction("Index");
                }

                return View(product);

            }
            catch {
                return View();
            }

            
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
        [NonAction]
        public static List<Models.Product> GetProducts() {
            return ListProduct;
        }

    }
}
