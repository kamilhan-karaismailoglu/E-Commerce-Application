using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatemogluApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AltKategoriler : ContentPage
    {
        readonly AltKategorilerViewModel altKategorilerViewModel;
        public AltKategoriler(string tur)
        {
            altKategorilerViewModel = new AltKategorilerViewModel();
            InitializeComponent();
            AltKategorilerViewModel.InitializeViewModel(tur);
            BindingContext = altKategorilerViewModel;
        }

        private async void alt_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(new Urunler(btn.Text));
        }

        private async void AllButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Urunler(title.Text));
        }
    }
}