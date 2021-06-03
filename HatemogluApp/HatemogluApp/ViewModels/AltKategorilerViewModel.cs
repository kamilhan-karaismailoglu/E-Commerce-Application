using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HatemogluApp.ViewModels
{
    class AltKategorilerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static string title;
        private static string alt1;
        private static string alt2;
        private static string alt3;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }
        public string Alt1
        {
            get => alt1;
            set
            {
                alt1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Alt1"));
            }
        }
        public string Alt2
        {
            get => alt2;
            set
            {
                alt2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Alt2"));
            }
        }
        public string Alt3
        {
            get => alt3;
            set
            {
                alt3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Alt3"));
            }
        }
        public Command LogoCommand
        {
            get
            {
                return new Command(AnasayfayaGit);
            }
        }
        public Command SepetCommand
        {
            get
            {
                return new Command(SepeteGit);
            }
        }
        private async void AnasayfayaGit()
        {
            await AppShell.Current.GoToAsync($"//anasayfa");
        }
        private async void SepeteGit()
        {
            await AppShell.Current.GoToAsync($"//sepetim");
        }
        public static void InitializeViewModel(string tur) 
        {
            if (tur == "gomlek")
            {
                title = "Gömlekler";
                alt1 = "Slim Fit Gömlekler";
                alt2 = "Spor Gömlekler";
                alt3 = "Klasik Gömlekler";
            }
            else if (tur == "ceket")
            {
                title = "Ceketler";
                alt1 = "Slim Fit Ceketler";
                alt2 = "Spor Ceketler";
                alt3 = "Klasik Ceketler";
            }
            else if (tur == "tisort")
            {
                title = "Tişörtler";
                alt1 = "Bisiklet Yaka Tişörtler";
                alt2 = "Polo Tişörtler";
                alt3 = "Hakim Yaka Tişörtler";
            }
            else if (tur == "kazak")
            {
                title = "Kazaklar";
                alt1 = "Boğazlı Kazaklar";
                alt2 = "Bisiklet Yaka Kazaklar";
                alt3 = "V Yaka Kazaklar";
            }
            else if (tur == "pantolon")
            {
                title = "Pantolonlar";
                alt1 = "Slim Fit Pantolonlar";
                alt2 = "Klasik Pantolonlar";
                alt3 = "Kot Pantolonlar";
            }
        }
    }
}
