using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadankozbazadanych.Models;

namespace zadankozbazadanych.Data
{
    public class NumbersContext : DbContext
    {
       private  NumbersContext _context;
       public NumbersContext(DbContextOptions options) : base(options) { }
       public DbSet<Numbers> Numbers { get; set; }

        public void GetMessage(Numbers item)
        {
            _context.Remove(item);
        }
    }
}
