using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Models
{
    public class BusDriverViewModel
    {
        public int Boarding { get; set; }
        public int Exiting { get; set; }

        

        public void OnGet()
        {
            Boarding = 0;
            Exiting = 0;
        }
        /*

        public void IncreaseOnBoard()
        {
            Boarding++;
        }

        public void DecreaseOnBoard()
        {
            Boarding--;
        }

        public void IncreaseDeparting()
        {
            Exiting++;
        }

        public void DecreaseDeparting()
        {
            Exiting--;
        }
        */
        

    }
}