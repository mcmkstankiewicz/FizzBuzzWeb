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
        [Range(1, 1000)]
        public int Liczba { get; set; }

        
        public string Wiadomosc { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Liczba % 15 == 0)
                    Wiadomosc = "fizzbuzz";
                else if (Liczba % 5 == 0)
                    Wiadomosc = "buzz";
                else if (Liczba % 3 == 0)
                    Wiadomosc = "fizz";
                else
                    Wiadomosc = $"Liczba {Liczba} nie spełnia kryteriów Fizz/Buzz";
            }
        }
    }
}
