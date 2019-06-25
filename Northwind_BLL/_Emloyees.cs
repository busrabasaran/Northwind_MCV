using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind_BLL
{
    public static class _Emloyees
    {

        public static NorthwindContext db = new NorthwindContext();

        public static List<Employee> Get_Employes()
        {
            return db.Employees.ToList();
        }

        public static void Add_Employes(Employee NewEmployes)
        {
            if (NewEmployes.EmployeeID == 0)
            {
                db.Employees.Add(NewEmployes);
            }
            else
            {
                var a = db.Employees.Find(NewEmployes.EmployeeID);

                a.FirstName = NewEmployes.FirstName;
                a.LastName = NewEmployes.LastName;
                a.Title = NewEmployes.Title;
                a.TitleOfCourtesy = NewEmployes.TitleOfCourtesy;
                a.BirthDate = NewEmployes.BirthDate;
                a.HireDate = NewEmployes.HireDate;
                a.Address = NewEmployes.Address;
                a.City = NewEmployes.City;
                a.Region = NewEmployes.Region;
                a.PostalCode = NewEmployes.PostalCode;
                a.Country = NewEmployes.Country;
                a.HomePhone = NewEmployes.HomePhone;
                a.Extension = NewEmployes.Extension;
                a.Photo = NewEmployes.Photo;
                a.ReportsTo = NewEmployes.ReportsTo;
                a.Notes = NewEmployes.Notes;
                a.PhotoPath = NewEmployes.PhotoPath;

            }
            db.SaveChanges();
        }

        public static Employee EmployesUpdate(int id)
        {
            var Employes = db.Employees.Find(id);
            return Employes;
        }

        public static void EmployesDelete(int id)
        {
            var Employes = db.Employees.Find(id);
            db.Employees.Remove(Employes);
            db.SaveChanges();
        }
    }
}
