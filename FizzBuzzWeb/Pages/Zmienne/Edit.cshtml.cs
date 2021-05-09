using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages.Zmienne
{
    public class EditModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.ZmiennaContext _context;

        public EditModel(FizzBuzzWeb.Data.ZmiennaContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wartosc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WartoscExists(Wartosc.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WartoscExists(int id)
        {
            return _context.Wartosc.Any(e => e.Id == id);
        }
    }
}
