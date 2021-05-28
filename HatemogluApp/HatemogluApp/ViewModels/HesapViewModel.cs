using HatemogluApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HatemogluApp.ViewModels
{
    class HesapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string isim;
        string soyisim;
        string telefon;
        string email;
        string sifre;

        public string Isim
        {
            get => isim;
            set
            {
                isim = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Isim"));
            }
        }
        public string Soyisim
        {
            get => soyisim;
            set
            {
                soyisim = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Soyisim"));
            }
        }
        public string Telefon
        {
            get => telefon;
            set
            {
                telefon = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Telefon"));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        public string Sifre
        {
            get => sifre;
            set
            {
                sifre = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Sifre"));
            }
        }

        public Command CikisCommand
        {
            get
            {
                return new Command(Cikis_Clicked);
            }
        }
        public Command HesapCommand
        {
            get
            {
                return new Command(HesabıGetir);
            }
        }

        public async void Cikis_Clicked()
        {
            LoginPage.SepettenMiGeldin = 0;
            Sepetim.GirisYaptıMı = 0;
            Hesap.user = null;
            await App.Current.MainPage.Navigation.PopAsync();
        }
        public async void HesabıGetir()
        {
            string mail = Hesap.staticMail;

            var kullanıcı = await FirebaseHelper.GetUser(mail);
            Isim = kullanıcı.Isim;
            Soyisim = kullanıcı.Soyisim;
            Email = kullanıcı.Email;
            Telefon = kullanıcı.Telefon;
            Sifre = kullanıcı.Sifre;

            Hesap.user = kullanıcı;
        }
    }
}
