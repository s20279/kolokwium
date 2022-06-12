using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kolokwiumEF.Models.DTOs
{
    public class AddZamowienieRequest
    {
        [Required]
        public DateTime DataPrzyjecia { get; set; }
        public string? Uwagi { get; set; }
        [Required]
        public IEnumerable<Wyroby> Wyroby { get; set; }
    }

    public class Wyroby
    {
        public int Ilosc { get; set; }
        public string Wyrob { get; set; }
        public string? Uwagi { get; set; }
    }
}
