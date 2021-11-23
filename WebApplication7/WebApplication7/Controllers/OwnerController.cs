using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using WebApplication7.viewmodel;

namespace WebApplication7.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        private FinalEntities1 _owner;
        public OwnerController()
        {
            _owner = new FinalEntities1();
        }
        public ActionResult OwnerPage()
        {


            return View();
        }
        public ActionResult ShowOwner()
        {
            var owner = _owner.Owners.ToList();
            return View(owner);
        }
        public ActionResult AddOwner()
        {
            return View();
        }
        public ActionResult SaveOwner(Owner o)
        {
            _owner.Owners.Add(o);
            _owner.SaveChanges();
            return RedirectToAction("ShowOwner");

        }

        public ActionResult ShowVehicle()
        {
            var vehicle = _owner.Vehicles.Where(v=>v.Occupied==true).ToList();
            return View(vehicle);
        }

        [HttpPost]

        public ActionResult SaveVehicle(NewVehicle v)
        {
            if (ModelState.IsValid)
            {
                v.Vehicle.Occupied = true;
            }
            
            _owner.Vehicles.Add(v.Vehicle);
            _owner.SaveChanges();
            return RedirectToAction("ShowVehicle");
        }
        public ActionResult AddVehicle()
        {
            var owner = _owner.Owners.ToList();

            NewVehicle vehicle = new NewVehicle()
            {
                Owners=owner
            };

            return View(vehicle);
        }
       
        public ActionResult update()
        {
            var vehicle = _owner.Vehicles.ToList();
            BookingViewmodel v = new BookingViewmodel()
            {
                Vehicles = vehicle

            };



            return View(v);

            } 
        public ActionResult saveupdate(BookingViewmodel b)

        {
            var up = _owner.Vehicles.Single(v => v.Vno == b.Booking.Bvno);
            up.Occupied = true;
            _owner.SaveChanges();
            return RedirectToAction("update");
          
                
        }
       
    }

}