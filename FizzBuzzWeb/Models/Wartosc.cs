using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzWeb.Models
{
    public class Wartosc
    {
        [Range(1, 1000)]
        public int Liczba { get; set; }
        public string Wiadomosc { get; set; }
        
        public DateTime Czas { get; set; }
    }
}
