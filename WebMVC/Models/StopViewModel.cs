using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Models
{
    public class StopViewModel : PageModel
    {
        public Guid Id;
        public string Name;
        public double Latitude;
        public double Longitude;


    }
}