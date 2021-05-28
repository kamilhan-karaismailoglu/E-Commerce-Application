using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatemogluApp.Databases;
using HatemogluApp.Models;
using HatemogluApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeslimatAdresi : ContentPage
    {
        public static double staticToplam;
        readonly TeslimatAdresiViewModel TeslimatAdresiViewModel;

        public TeslimatAdresi(double toplam)
        {
            staticToplam = toplam;
            TeslimatAdresiViewModel = new TeslimatAdresiViewModel();
            InitializeComponent();
            BindingContext = TeslimatAdresiViewModel;
        }       
    }
}