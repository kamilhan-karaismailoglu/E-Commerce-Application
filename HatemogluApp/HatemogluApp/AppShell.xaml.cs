using HatemogluApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HatemogluApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Anasayfa), typeof(Anasayfa));
            Routing.RegisterRoute(nameof(Arama), typeof(Arama));
            Routing.RegisterRoute(nameof(Sepetim), typeof(Sepetim));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(UyeOl), typeof(UyeOl));
            Routing.RegisterRoute(nameof(Kategoriler), typeof(Kategoriler));
        }
    }
}
