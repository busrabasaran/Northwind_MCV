using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_BLL
{
    public static class _Categories
    {
        public static NorthwindContext db = new NorthwindContext();

        public static List<Category> Get_Categories()
        {
            return db.Categories.ToList();
        }

        public static void Add_Category(Category NewCategory)
        {
            if (NewCategory.CategoryID == 0)
            {
                db.Categories.Add(NewCategory);
            }
            else
            {
                var a = db.Categories.Find(NewCategory.CategoryID);

                a.CategoryName = NewCategory.CategoryName;
                a.Description = NewCategory.Description;

            }
            db.SaveChanges();
        }

        public static Category CategoriesUpdate(int id)
        {
            var Category = db.Categories.Find(id);
            return Category;
        }

        public static void CateoriesDelete(int id)
        {
            var Category = db.Categories.Find(id);
            db.Categories.Remove(Category);
            db.SaveChanges();
        }
    }
}
