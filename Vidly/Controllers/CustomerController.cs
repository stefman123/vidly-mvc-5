using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        List<Customer> _customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Tom Jones"},
                new Customer {Id = 2, Name = "Sharleen Gayle"}
            };

        public ActionResult Index()
        {
          

            return View(_customers);
           
        }



        public ActionResult CustomerDetails(int? id)
        {
         var  details =  _customers.Find(x => x.Id == id);
            if (details == null) throw new ArgumentNullException(nameof(details));
            var customer = details; 
            return View(customer);
        }

    }
}