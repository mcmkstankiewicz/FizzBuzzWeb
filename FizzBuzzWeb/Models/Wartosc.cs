using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FizzBuzzWeb.Models
{
    public class Wartosc
    {
        [Range(1, 1000)]
        public int Liczba { get; set; }
        public string Wiadomosc { get; set; }
    }
}
