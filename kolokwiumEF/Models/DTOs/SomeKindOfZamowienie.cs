using System;
using System.Collections.Generic;

namespace kolokwiumEF.Models.DTOs
{
    public class SomeKindOfZamowienie
    {
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string? Uwagi { get; set; }
        public Osoba Klient { get; set; }
        public Osoba Pracownik { get; set; }
        public IEnumerable<SomeKindOfZamowienieWyrobCukierniczy> WyrobyCukiernicze { get; set; }
    }
}
