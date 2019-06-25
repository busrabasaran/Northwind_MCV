using Northwind_BLL;
using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind_MCV.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Categories()
        {
            var CategoryList= _Categories.Get_Categories();
            return View(CategoryList);
        }

        [HttpGet]
        public ActionResult CategoriesSave()
        {

            return View("CategoriesForm",new Category());
        }

        [HttpPost]
        public ActionResult CategoriesSave(Category NewCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoriesForm");
            }
            _Categories.Add_Category(NewCategory);
            return RedirectToAction("Categories","Category");
        }

        public ActionResult CategoriesUpdate(int id)
        {
             var Category= _Categories.CategoriesUpdate(id);

            return View("CategoriesForm",Category);
        }

        public ActionResult CategoriesDelete(int id)
        {
            _Categories.CateoriesDelete(id);

            return RedirectToAction("Categories", "Category");
        }
    }
}