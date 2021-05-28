using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using SQLite;

namespace HatemogluApp.Models
{
    public class Profil
    {
        private string isim;
        private string soyisim;
        private string email;
        private string telefon;
        private string sifre;
        public string Isim { get { return isim; } set { isim = value; } }
        public string Soyisim { get { return soyisim; } set { soyisim = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Telefon { get { return telefon; } set { telefon = value; } }
        public string Sifre { get { return sifre; } set { sifre = value; } }

    }
}
