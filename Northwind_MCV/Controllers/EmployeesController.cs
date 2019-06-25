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
    public class EmployeesController : Controller
    {
        NorthwindContext db = new NorthwindContext();
        // GET: Employees
        public ActionResult Employees()
        {
            var Employees = _Emloyees.Get_Employes();
            return View(Employees);
        }

        [HttpGet]
        public ActionResult EmployeesSave()
        {
            var emploee = new EmloyeesViewModel
            {
                Ragion=db.Regions
            };
            return View("EmployeesForm",emploee);
        }

        [HttpPost]
        public ActionResult EmployeesSave(EmloyeesViewModel NewEmployee)
        {
            _Emloyees.Add_Employes(NewEmployee.Employee);
            return RedirectToAction("Employees", "Employees");
        }


        public ActionResult EmployeesUpdate(int id)
        {
            var Employees = new EmloyeesViewModel
            {
                Employee=_Emloyees.EmployesUpdate(id),
                Ragion=db.Regions
                
            };
            return View("EmployeesForm", Employees);
        }

        public ActionResult EmployeesDelete(int id)
        {
            _Emloyees.EmployesDelete(id);

            return RedirectToAction("Employees", "Employees");
        }
    }
}