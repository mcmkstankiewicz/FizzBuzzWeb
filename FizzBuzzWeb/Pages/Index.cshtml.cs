using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public Wartosc Zmienna { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Zmienna.Liczba % 15 == 0)
                    Zmienna.Wiadomosc = "fizzbuzz";
                else if (Zmienna.Liczba % 5 == 0)
                    Zmienna.Wiadomosc = "buzz";
                else if (Zmienna.Liczba % 3 == 0)
                    Zmienna.Wiadomosc = "fizz";
                else
                    Zmienna.Wiadomosc = $"Liczba {Zmienna.Liczba} nie spełnia kryteriów Fizz/Buzz";
                HttpContext.Session.SetString("SesjaZmienna", JsonConvert.SerializeObject(Zmienna));
            }
        }
        
    }
}
