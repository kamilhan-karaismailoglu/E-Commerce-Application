using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HatemogluApp.Databases;
using HatemogluApp.Models;
using HatemogluApp.ViewModels;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly LoginPageViewModel loginPageViewModel;

        static public int SepettenMiGeldin = 0;
        public LoginPage()
        {
            loginPageViewModel = new LoginPageViewModel();
            InitializeComponent();
            BindingContext = loginPageViewModel;
        }    
    }
}