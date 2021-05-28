using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using HatemogluApp.Models;
using HatemogluApp.Databases;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using HatemogluApp.ViewModels;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UyeOl : ContentPage
    {
        readonly UyeOlViewModel UyeOlViewModel;
        public UyeOl()
        {
            UyeOlViewModel = new UyeOlViewModel();
            InitializeComponent();
            BindingContext = UyeOlViewModel;
        }
    }
}