using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication7.Models;
using WebApplication7.viewmodel;

namespace WebApplication7.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        private FinalEntities1 _booking;
        public BookingController()
        {
            _booking = new FinalEntities1();
        }
         
        public ActionResult AddBooking()
        {
            BookingViewmodel viewmodel = new BookingViewmodel()
            {
                Locations = _booking.Locations.ToList(),
                Customers = _booking.Customers.ToList(),
                Vehicles=_booking.Vehicles.ToList(),

            };
            return View(viewmodel);
        }

       
        public ActionResult Success(Booking b)
        {
           

            return View(b);
        }


        [HttpPost]

        public ActionResult SaveBooking(BookingViewmodel b)
        {
            var vehicle = _booking.Vehicles.FirstOrDefault(v => v.Vno == b.Booking.Bvno);
            var Locationfrom = _booking.Locations.FirstOrDefault(l => l.location1 == b.Booking.Bfrom);
            var Locationto = _booking.Locations.FirstOrDefault(l => l.location1 == b.Booking.Bto);
           
            var Amount = Math.Abs(Locationto.distance - Locationfrom.distance) * vehicle.Rate;
            var upoccupied = _booking.Vehicles.Single(v => v.Vno == b.Booking.Bvno);
            upoccupied.Occupied = false;
            b.Booking.price = Amount;
            
                
            _booking.Bookings.Add(b.Booking);
            _booking.SaveChanges();

            return RedirectToAction("Success",b.Booking);
        }
    }
}