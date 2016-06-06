using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        //generating, encripting and validating a token  is done by the asp mvc framework 
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            //New Customer
            if (customer.Id == 0)
                _context.Customers.Add(customer); //Create in memory
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            //persist changes - generate sql statements at runtime in transaction statement
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }




        public ActionResult CustomerDetails(int? id)
        {
            //var  details = GetCustomers().SingleOrDefault(x => x.Id == id);
            var  details = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (details == null) return HttpNotFound();
            var customer = details; 
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()


            };
            return View("CustomerForm", viewModel);
        }
    }
}