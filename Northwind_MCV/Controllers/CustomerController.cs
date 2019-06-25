using Northwind_BLL;
using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind_MCV.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Customer()
        {
             var customer= _Customer.Get_Customer();
            return View(customer);
        }

        [HttpGet]
        public ActionResult CustomerSave()
        {
            return View("CustomerForm");
        }

        [HttpPost]
        public ActionResult CustomerSave(Customer NewCustomer)
        {
            if (!ModelState.IsValidField("CompanyName"))
            {
                return View("CustomerForm");
            }
            if (!ModelState.IsValidField("CustomerID"))
            {
                return View("CustomerForm");
            }

            _Customer.Add_Customer(NewCustomer);
            return RedirectToAction("Customer","Customer");
        }

        public ActionResult CustomerUpdate(string id)
        {
            var Customer = _Customer.CustomerUpdate(id);

            return View("CustomerForm", Customer);
        }

        public ActionResult CustomerDelete(string id)
        {
            _Customer.CustomerDelete(id);

            return RedirectToAction("Customer", "Customer");
        }

    }
}