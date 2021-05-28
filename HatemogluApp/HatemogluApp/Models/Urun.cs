using System;
using System.Collections.Generic;
using System.Text;

namespace HatemogluApp.Models
{
    class Urun
    {
        private string baslik;
        private string resim;
        private string indirim;
        private string eskifiyat;
        private string fiyat;
        private string ozellikler;
        private string tur;
        private string beden;
        private double toplam;
        public string Resim { get { return resim; } set { resim = value; } }
        public string Baslik { get { return baslik; } set { baslik = value; } }
        public string Indirim { get { return indirim; } set { indirim = value; } }
        public string Eskifiyat { get { return eskifiyat; } set { eskifiyat = value; } }
        public string Fiyat { get { return fiyat; } set { fiyat = value; } }
        public string Ozellikler { get { return ozellikler; } set { ozellikler = value; } }
        public string Tur { get { return tur; } set { tur = value; } }
        public string Beden { get { return beden; } set { beden = value; } }
        public double Toplam { get { return toplam; } set { toplam = value; } }
    }
}
