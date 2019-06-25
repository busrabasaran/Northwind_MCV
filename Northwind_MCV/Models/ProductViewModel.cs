using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind_MCV.Models
{
    public class ProductViewModel
    {
        
        public Product Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Supplier> Supplier { get; set; }
    }
}