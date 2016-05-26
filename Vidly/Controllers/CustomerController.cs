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

        List<Customer> customers = new List<Customer>
            {
                new Customer {ID = 1, Name = "Tom Jones"},
                new Customer {ID = 2, Name = "Sharleen Gayle"}
            };

        public ActionResult Index()
        {
          

            return View(customers);
           
        }



        public ActionResult CustomerDetails(int? ID)
        {
         var  details =  customers.Find(x => x.ID == ID);
            if (details == null) throw new ArgumentNullException(nameof(details));
            var customer = details; 
            return View(customer);
        }

    }
}