using System;
using System.Collections.Generic;
using System.Text;

namespace HatemogluApp.Models
{
    class KrediKartı
    {
        private string adSoyad;
        private string kartNumarası;
        private int ay;
        private int yıl;
        private long cvv;
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string KartNumarası { get => kartNumarası; set => kartNumarası = value; }
        public int Ay { get => ay; set => ay = value; }
        public int Yıl { get => yıl; set => yıl = value; }
        public long CVV { get => cvv; set => cvv = value; }
    }
}
