using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_BLL
{
    public static class _Customer
    {
        public static NorthwindContext db = new NorthwindContext();

        public static List<Customer> Get_Customer()
        {
            return db.Customers.ToList();
        }

        public static void Add_Customer(Customer NewCustomer)
        {
            if (db.Customers.Where(x=>x.CustomerID==NewCustomer.CustomerID).Count()==0)
            {
                db.Customers.Add(NewCustomer);
            }
            else
            {
               var a=db.Customers.Find(NewCustomer.CustomerID);
                a.CompanyName = NewCustomer.CompanyName;
                a.ContactName = NewCustomer.ContactName;
                a.ContactTitle = NewCustomer.ContactTitle;
                a.Country = NewCustomer.Country;
                a.Address = NewCustomer.Address;
                a.City = NewCustomer.City;
                a.PostalCode = NewCustomer.PostalCode;
                a.Region = NewCustomer.Region;
                a.Fax = NewCustomer.Fax;
                a.Phone = NewCustomer.Phone;
            }

            db.SaveChanges();
        }

        public static Customer CustomerUpdate(string id)
        {
            var Customer = db.Customers.Find(id);
            return Customer;
        }

        public static void CustomerDelete(string id)
        {
            var Customer =db.Customers.Where(x => x.CustomerID == id);
            db.Customers.RemoveRange(Customer);
            db.SaveChanges();
        }


    }
}
