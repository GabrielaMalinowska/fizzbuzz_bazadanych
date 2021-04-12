using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadankozbazadanych.Data;
using zadankozbazadanych.Models;

namespace zadankozbazadanych.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty]
        public Numbers Numbers { get; set; }
        public string Kolor;
        public string Ocena;

        private readonly NumbersContext _context;

        public IndexModel(ILogger<IndexModel> logger, NumbersContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Name = "User";
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
               Numbers.Data = DateTime.Now;
                if (Numbers.Number % 15 == 0)
                {
                    Ocena = "FizzBuzz";
                    Kolor = "pink";

                }
                else if (Numbers.Number % 3 == 0)
                {
                    Ocena = "Fizz";

                    Kolor = "green";
                }
                else if (Numbers.Number % 5 == 0)
                {
                    Ocena = "Buzz";

                    Kolor = "blue";

                }
                else
                {
                    Ocena = "Liczba " + Numbers.Number + " nie spełnia warunków zadania Fizz/Buzz! ";

                    Kolor = "red";
                }
                Numbers.Ocena = Ocena;
                _context.Add(Numbers);
                _context.SaveChanges();

                //_context.Remove(Numbers);
                HttpContext.Session.SetString("SessionNumbers", JsonConvert.SerializeObject(Numbers));
                //return RedirectToPage("./Index");
            }
            return Page();
        }

    }
}
