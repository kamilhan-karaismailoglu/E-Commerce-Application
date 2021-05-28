using HatemogluApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anasayfa : ContentPage
    {
        readonly AnasayfaViewModel AnasayfaViewModel;

        public Anasayfa()
        {
            AnasayfaViewModel = new AnasayfaViewModel();
            InitializeComponent();
            BindingContext = AnasayfaViewModel;
        }
    }
}