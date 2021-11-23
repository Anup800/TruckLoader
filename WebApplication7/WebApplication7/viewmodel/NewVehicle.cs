using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.viewmodel
{
    public class NewVehicle
    {
        public IEnumerable<Owner> Owners { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}