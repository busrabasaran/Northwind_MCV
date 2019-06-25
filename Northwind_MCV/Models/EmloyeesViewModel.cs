using Northwind_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind_MCV.Models
{
    public class EmloyeesViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Region> Ragion { get; set; }
    }
}