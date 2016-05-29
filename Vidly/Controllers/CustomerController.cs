using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        
        //DbContext is a disposable object => so have to properly dispose of it
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer 
        private IEnumerable<Customer> GetCustomers() {
            //Hardcoded getting customers
            return  new List<Customer>
            {
                new Customer {Id = 1, Name = "Tom Jones"},
                new Customer {Id = 2, Name = "Sharleen Gayle"}
            };
        }

        public ActionResult Index()
        {

            ////var _customers = GetCustomers().ToList();
            ////Get all customers from database
            //var customers = _context.Customers.ToList();

            //Eager Loading - using "Include" allows you to load related objects e.g customer => MembershipType 

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);
           
        }




        public ActionResult CustomerDetails(int? id)
        {
            //var  details = GetCustomers().SingleOrDefault(x => x.Id == id);
            var  details = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (details == null) return HttpNotFound();
            var customer = details; 
            return View(customer);
        }

    }
}