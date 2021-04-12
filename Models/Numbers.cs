using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadankozbazadanych.Models
{
    public class Numbers
    {
        public int Id { get; set; }
        [Display(Name = "Numer")]
        [Range(0, 1000), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int Number { get; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Komunikat")]
        public string Ocena { get; set; }

    }
}
