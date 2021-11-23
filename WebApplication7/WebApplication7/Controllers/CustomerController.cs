using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class CustomerController : Controller
    {
        private FinalEntities1 _cust;
        public CustomerController()
        {
            _cust = new FinalEntities1();
        }
        // GET: Customer
        public ActionResult ShowCustomers()
        {
            var customer = _cust.Customers.ToList();
            return View(customer);
        }
        public ActionResult AddCustomer()
        {
            return View();

        }

        [HttpPost]
        public ActionResult SaveCustomer(Customer c)
        {
            _cust.Customers.Add(c);
            _cust.SaveChanges();
            return RedirectToAction("ShowCustomers");
        }
    
       
    public ActionResult CustomerLogin()
        {
            return View();
        }
    
    
    
    
    
    
    }



}