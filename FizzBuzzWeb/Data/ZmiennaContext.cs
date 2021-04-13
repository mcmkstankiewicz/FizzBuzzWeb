using FizzBuzzWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzWeb.Data
{
    public class ZmiennaContext : DbContext
    {
        public ZmiennaContext(DbContextOptions options) : base(options) { }
        public DbSet<Wartosc> Wartosc { get; set; }
    }
}
