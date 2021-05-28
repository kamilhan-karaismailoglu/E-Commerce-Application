using System;
using System.Collections.Generic;
using System.Text;

namespace HatemogluApp.Models
{
    public class Adres
    {
        private string baslık;
        private string adSoyad;
        private long telefon;
        private string ulke;
        private string sehir;
        private string ilce;
        private string tamAdres;

        public string TamAdres { get => tamAdres; set => tamAdres = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Ulke { get => ulke; set => ulke = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string Baslık { get => baslık; set => baslık = value; }
        public long Telefon { get => telefon; set => telefon = value; }
    }
}
