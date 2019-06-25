using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_BLL
{
    public static class _Product
    {
        public static NorthwindContext db = new NorthwindContext();

        public static List<Product> Get_Product()
        {
            return db.Products.ToList();
        }

        public static void Add_Product(Product NewProduct)
        {
            if (NewProduct.ProductID == 0)
            {
                db.Products.Add(NewProduct);
            }
            else
            {
                var a = db.Products.Find(NewProduct.ProductID);

                a.ProductName = NewProduct.ProductName;
                a.QuantityPerUnit = NewProduct.QuantityPerUnit;
                a.ReorderLevel = NewProduct.ReorderLevel;
                a.SupplierID = NewProduct.SupplierID;
                a.UnitPrice = NewProduct.UnitPrice;
                a.UnitsInStock = NewProduct.UnitsInStock;
                a.UnitsOnOrder = NewProduct.UnitsOnOrder;
                a.CategoryID = NewProduct.CategoryID;
                a.Discontinued = NewProduct.Discontinued;

            }
            db.SaveChanges();
        }

        public static Product ProductUpdate(int id)
        {
            var Product = db.Products.Find(id);
            return Product;
        }

        public static void ProductDelete(int id)
        {
            var Product = db.Products.Find(id);
            db.Products.Remove(Product);
            db.SaveChanges();
        }
    }
}
