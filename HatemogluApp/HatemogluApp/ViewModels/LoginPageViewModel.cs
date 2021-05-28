using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Firebase.Auth;
using HatemogluApp.Views;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace HatemogluApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static string Web_API_Key = "AIzaSyCrhGhMG_BQS_rwf4svmZ0_MEOF86aV5_M";

        public LoginPageViewModel()
        {

        }

        string email;
        string sifre;
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
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new UyeOl()); });
            }
        }

        private async void Login()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Web_API_Key));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Sifre);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontent);

                Sepetim.GirisYaptıMı = 1;

                await App.Current.MainPage.Navigation.PushAsync(new Hesap(email));

                if (LoginPage.SepettenMiGeldin == 1)
                {
                    await AppShell.Current.GoToAsync($"//sepetim");
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Lütfen Tekrar Deneyin", "Mail Adresi Veya Şifre Hatalı", "Tamam");
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
    }
}
