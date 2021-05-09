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
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.ZmiennaContext _context;

        public DeleteModel(FizzBuzzWeb.Data.ZmiennaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wartosc Wartosc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wartosc = await _context.Wartosc.FirstOrDefaultAsync(m => m.Id == id);

            if (Wartosc == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wartosc = await _context.Wartosc.FindAsync(id);

            if (Wartosc != null)
            {
                _context.Wartosc.Remove(Wartosc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
