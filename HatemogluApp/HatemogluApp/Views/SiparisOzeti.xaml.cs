using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatemogluApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SiparisOzeti : ContentPage
    {
        static double staticToplam;
        public static Adres staticAdres;
        public SiparisOzeti()
        {
            InitializeComponent();
        }
        public SiparisOzeti(Adres adres,double toplam)
        {
            InitializeComponent();
            staticToplam = toplam;
            staticAdres = adres;
        }
        private async void Button_Clicked_logo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//anasayfa");
        }
        protected override async void OnAppearing()
        {
            liste.ItemsSource = await App.Database.GetUrunsAsync();
            total.Text = staticToplam.ToString();
            lblAdres.Text = staticAdres.TamAdres;
            lblSehir.Text = staticAdres.Sehir;
            lblBaslık.Text = staticAdres.Baslık;
            lblAdSoyad.Text = staticAdres.AdSoyad;
            lblIlce.Text = staticAdres.Ilce;
            lblUlke.Text = staticAdres.Ulke;
            lblTelefon.Text = staticAdres.Telefon.ToString();
        }

        private async void OdemeyeGec_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Odeme(staticToplam));
        }
    }
}