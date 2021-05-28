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
        public AltKategoriler()
        {
            InitializeComponent();
        }
        public AltKategoriler(string tur)
        {
            InitializeComponent();

            if (tur == "gomlek")
            {
                title.Text = "Gömlekler";
                alt1.Text = "Slim Fit Gömlekler";
                alt2.Text = "Spor Gömlekler";
                alt3.Text = "Klasik Gömlekler";
            }
            else if (tur == "ceket")
            {
                title.Text = "Ceketler";
                alt1.Text = "Slim Fit Ceketler";
                alt2.Text = "Spor Ceketler";
                alt3.Text = "Klasik Ceketler";
            }
            else if (tur == "tisort")
            {
                title.Text = "Tişörtler";
                alt1.Text = "Bisiklet Yaka Tişörtler";
                alt2.Text = "Polo Tişörtler";
                alt3.Text = "Hakim Yaka Tişörtler";
            }
            else if (tur == "kazak")
            {
                title.Text = "Kazaklar";
                alt1.Text = "Boğazlı Kazaklar";
                alt2.Text = "Bisiklet Yaka Kazaklar";
                alt3.Text = "V Yaka Kazaklar";
            }
            else if (tur == "pantolon")
            {
                title.Text = "Pantolonlar";
                alt1.Text = "Slim Fit Pantolonlar";
                alt2.Text = "Klasik Pantolonlar";
                alt3.Text = "Kot Pantolonlar";
            }        
        }
        private async void Button_Clicked_logo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//anasayfa");
        }
        private async void Button_Clicked_sepetim(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//sepetim");
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