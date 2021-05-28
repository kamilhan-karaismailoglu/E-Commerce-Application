using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HatemogluApp.Models
{
    public class SepetUrun
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string baslik;
        private string resim;
        private string indirim;
        private string eskifiyat;
        private string fiyat;
        private string beden;
        private int adet =1;
        public string Resim { get { return resim; } set { resim = value; } }
        public string Baslik { get { return baslik; } set { baslik = value; } }
        public string Indirim { get { return indirim; } set { indirim = value; } }
        public string Eskifiyat { get { return eskifiyat; } set { eskifiyat = value; } }
        public string Fiyat { get { return fiyat; } set { fiyat = value; } }
        public string Beden { get { return beden; } set { beden = value; } }
        public int Adet { get { return adet; } set { adet = value; } }
        public double Toplam { get { return Convert.ToDouble(fiyat)*Convert.ToDouble(adet); }  }
    }
}
