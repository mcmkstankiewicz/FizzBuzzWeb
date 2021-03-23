using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages
{
    public class OstatnioSzukaneModel : PageModel
    {
        public Wartosc Zmienna { get; set; }

        public void OnGet()
        {
            var SesjaZmienna = HttpContext.Session.GetString("SesjaZmienna");
            if (SesjaZmienna != null)
                Zmienna = JsonConvert.DeserializeObject<Wartosc>(SesjaZmienna);
        }
    }
}
