using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using zadankozbazadanych.Models;
using zadankozbazadanych.Data;

namespace zadankozbazdanych.Pages
{
    public class ListnumbersModel : PageModel
    {
        private string sessionNumbers;

        public Numbers Numbers { get; private set; }
        public List<Numbers> ListNumbers = new List<Numbers>();
        private readonly NumbersContext _context;

        public ListnumbersModel(NumbersContext context)
        {
            _context = context;
        }
        public IList<Numbers> numbers { get; set; }
        
        public IActionResult OnPost(int? Id)
        {
            foreach (var item in _context.Numbers.ToList())
            {
                if(item.Id == Id)
                {
                   Numbers = item;
                }
            }
            _context.Remove(Numbers);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
            public void OnGet()
            {
                /*var SessionNumbers = HttpContext.Session.GetString("SessionNumbers");
                if (SessionNumbers!= null)
                {
                    Numbers = JsonConvert.DeserializeObject<Numbers>(SessionNumbers);
                }*/


                numbers = _context.Numbers.ToList();

                //ListNumbers.Add(Numbers);

            }

        }
    }
