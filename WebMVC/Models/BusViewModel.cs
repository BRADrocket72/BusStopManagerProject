using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Models
{
    public class BusViewModel : PageModel
    {
        public Guid Id;
        public int BusNumber;


    }
}