using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages.Zmienne
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.ZmiennaContext _context;

        public IndexModel(FizzBuzzWeb.Data.ZmiennaContext context)
        {
            _context = context;
        }

        public IList<Wartosc> Wartosc { get;set; }

        public async Task OnGetAsync()
        {
            Wartosc = await _context.Wartosc.ToListAsync();
        }
    }
}
