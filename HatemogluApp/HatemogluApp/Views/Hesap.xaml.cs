using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using HatemogluApp.Databases;
using HatemogluApp.Models;
using HatemogluApp.ViewModels;
using HatemogluApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hesap : ContentPage
    {
        readonly HesapViewModel HesapViewModel;
        public static Profil user;
        public static string staticMail;
        public Hesap(string mail)
        {
            staticMail = mail;
            HesapViewModel = new HesapViewModel();
            InitializeComponent();
            BindingContext = HesapViewModel;
            HesapViewModel.HesabıGetir();
        }       
    }
}