using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;
using WebApplication7.Models;

namespace WebApplication7.viewmodel
{
    public class BookingViewmodel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public Booking Booking { get; set; }

       
    }
}