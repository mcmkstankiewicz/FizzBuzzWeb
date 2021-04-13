using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzWeb.Models
{
    public class Wartosc
    {
        public int Id { get; set; }
        [Range(1, 1000)]
        public int Liczba { get; set; }
        [MaxLength(60)]
        public string Wiadomosc { get; set; }
        
        public DateTime Czas { get; set; }
    }
}
