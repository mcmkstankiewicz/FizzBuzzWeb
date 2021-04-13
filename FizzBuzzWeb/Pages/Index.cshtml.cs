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
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IConfiguration _configuration { get; }
        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [BindProperty]
        public Wartosc Zmienna { get; set; }
        public void Fizzbuzz()
        {
            if (Zmienna.Liczba % 15 == 0)
                Zmienna.Wiadomosc = "fizzbuzz";
            else if (Zmienna.Liczba % 5 == 0)
                Zmienna.Wiadomosc = "buzz";
            else if (Zmienna.Liczba % 3 == 0)
                Zmienna.Wiadomosc = "fizz";
            else
                Zmienna.Wiadomosc = $"Liczba {Zmienna.Liczba} nie spełnia kryteriów Fizz/Buzz";
        }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Fizzbuzz();
                Zmienna.Czas = DateTime.Now;
                HttpContext.Session.SetString("SesjaZmienna", JsonConvert.SerializeObject(Zmienna));

                string fzbz_connect = _configuration.GetConnectionString("FizzbuzzDB");
                SqlConnection con = new SqlConnection(fzbz_connect);
                SqlCommand cmd = new SqlCommand("wartAdd", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter liczba_SqlPar = new SqlParameter("@Liczba", SqlDbType.Int);
                liczba_SqlPar.Value = Zmienna.Liczba;
                cmd.Parameters.Add(liczba_SqlPar);

                SqlParameter wiad_SqlPar = new SqlParameter("@Wiadomosc", SqlDbType.NVarChar, 60);
                wiad_SqlPar.Value = Zmienna.Wiadomosc;
                cmd.Parameters.Add(wiad_SqlPar);

                SqlParameter czas_SqlPar = new SqlParameter("@Czas", SqlDbType.DateTime2);
                czas_SqlPar.Value = Zmienna.Czas;
                cmd.Parameters.Add(czas_SqlPar);

                SqlParameter id_SqlPar = new SqlParameter("@Id", SqlDbType.Int);
                id_SqlPar.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id_SqlPar);

                con.Open();
                int numAff = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
    }
}
