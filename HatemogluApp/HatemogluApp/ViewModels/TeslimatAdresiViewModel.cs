using HatemogluApp.Models;
using HatemogluApp.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HatemogluApp.ViewModels
{
    class TeslimatAdresiViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string entryAdres;
        string entryBaslık;
        string entryAdSoyad;
        string entryTelefon;
        string entrySehir;
        string entryUlke;
        string entryİlce;

        public string EntryAdres
        {
            get => entryAdres;
            set
            {
                entryAdres = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EntryAdres"));
            }
        }
        public string EntryBaslık
        {
            get => entryBaslık;
            set
            {
                entryBaslık = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EntryBaslık"));
            }
        }
        public string EntryAdSoyad
        {
            get => entryAdSoyad;
            set
            {
                entryAdSoyad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EntryAdSoyad"));
            }
        }
        public string EntryTelefon
        {
            get => entryTelefon;
            set
            {
                entryTelefon = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EntryTelefon"));
            }
        }
        public string EntryUlke
        {
            get => entryUlke;
            set
            {
                entryUlke = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EntryUlke"));
            }
        }
        public string EntrySehir
        {
            get => entrySehir;
            set
            {
                entrySehir = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EntrySehir"));
            }
        }
        public string Entryİlce
        {
            get => entryİlce;
            set
            {
                entryİlce = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Entryİlce"));
            }
        }
        public Command OzeteGecCommand
        {
            get
            {
                return new Command(OzeteGec_Clicked);
            }
        }
        public Command LogoCommand
        {
            get
            {
                return new Command(Button_Clicked_logo);
            }
        }
        private async void Button_Clicked_logo()
        {
            await AppShell.Current.GoToAsync($"//anasayfa");
        }
        private async void OzeteGec_Clicked()
        {
            if (EntryAdres == null || EntryBaslık == null || EntryAdSoyad == null || EntryTelefon == null || EntrySehir == null || EntryUlke == null || Entryİlce == null ||
                EntryAdres == "" || EntryBaslık == "" || EntryAdSoyad == "" || EntryTelefon == "" || EntrySehir == "" || EntryUlke == "" || Entryİlce == "" ||
                EntryTelefon.Length < 10 || EntryAdSoyad.Length < 2 || EntryUlke.Length < 2 || EntrySehir.Length < 2 || EntryAdres.Length < 2)
            {
                await App.Current.MainPage.DisplayAlert("", "Lütfen Tüm Bilgileri Eksiksiz Girdiğinizden Emin Olunuz", "Tamam");
            }
            else
            {
                Adres adres = new Adres
                {
                    Baslık = EntryBaslık,
                    AdSoyad = EntryAdSoyad,
                    Ulke = EntryUlke,
                    Sehir = EntrySehir,
                    Ilce = Entryİlce,
                    TamAdres = EntryAdres,
                    Telefon = Convert.ToInt64(EntryTelefon)
                };
                await App.Current.MainPage.Navigation.PushAsync(new SiparisOzeti(adres, TeslimatAdresi.staticToplam));
            }
        }
    }
}
