using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Models
{
    public class EntryViewModel : PageModel
    {
        public Guid Id;
        public DateTime Timestamp;
        public int Boarded;
        public int LeftBehind;
        public DriverViewModel Driver;
        public LoopViewModel Loop;
    }
}