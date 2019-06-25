using Northwind_BLL;
using Northwind_DAL;
using Northwind_MCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind_MCV.Controllers
{
    public class ProductController : Controller
    {
        NorthwindContext db = new NorthwindContext();
        // GET: Product
        public ActionResult Product()
        {
            var product =_Product.Get_Product();
            return View(product);
        }

        [HttpGet]
        public ActionResult ProductSave()
        {
            var Product = new ProductViewModel
            {
                Category = db.Categories,
                Supplier=db.Suppliers
            };


            return View("ProductForm",Product);
        }

        [HttpPost]
        public ActionResult ProductSave(ProductViewModel NewProduct)
        {
            _Product.Add_Product(NewProduct.Product);
            return RedirectToAction("Product","Product");
        }


        public ActionResult ProductUpdate(int id)
        {


            var product = new ProductViewModel
            {
                Product=_Product.ProductUpdate(id),
                Category=db.Categories,
                Supplier=db.Suppliers
            };

            return View("ProductForm", product);
        }

        public ActionResult ProductDelete(int id)
        {
            _Product.ProductDelete(id);

            return RedirectToAction("Product", "Product");
        }
    }
}