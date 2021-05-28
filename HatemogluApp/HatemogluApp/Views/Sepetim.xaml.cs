using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatemogluApp.Models;
using HatemogluApp.Databases;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sepetim : ContentPage
    {
        static public int GirisYaptıMı = 0;
        static public double toplam = 0;
        public Sepetim()
        {   
            InitializeComponent();
            ToplamıHesapla();
            labetToplam.Text = toplam.ToString();
        }
        public Sepetim(double ekle)
        {
            InitializeComponent();
            toplam += ekle;
            labetToplam.Text = toplam.ToString();
        }
        private async void Button_Clicked_logo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//anasayfa");
        }
        protected override async void OnAppearing()
        {
            liste.ItemsSource = await App.Database.GetUrunsAsync();
            labetToplam.Text = toplam.ToString();
        }
        private async void ButtonDell_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = Convert.ToInt32(btn.Text);
            SepetUrun urun = await App.Database.GetSepetUrunAsync(index);

            toplam -= urun.Toplam;
            labetToplam.Text = toplam.ToString();
            if (labetToplam.Text == "2.8421709430404E-14")
            {
                labetToplam.Text = 0.ToString();
                toplam = 0;
            }
            else
            {
                labetToplam.Text = toplam.ToString();
            }

            await App.Database.DellUrunAsync(urun);
            liste.ItemsSource = await App.Database.GetUrunsAsync();
        }
        private async void Arttır_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = Convert.ToInt32(btn.Text);
            SepetUrun urun = await App.Database.GetSepetUrunAsync(index);

            toplam -= urun.Toplam;

            urun.Adet += 1;

            toplam += urun.Toplam;
            labetToplam.Text = toplam.ToString();

            await App.Database.SaveUrunAsync(urun);
            liste.ItemsSource = await App.Database.GetUrunsAsync();

        }
        private async void Azalt_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = Convert.ToInt32(btn.Text);
            SepetUrun urun = await App.Database.GetSepetUrunAsync(index);

            if (urun.Adet!=1)
            {
                toplam -= urun.Toplam;

                urun.Adet -= 1;
                await App.Database.SaveUrunAsync(urun);
                
                toplam += urun.Toplam;
                
                labetToplam.Text = toplam.ToString();
                liste.ItemsSource = await App.Database.GetUrunsAsync();
            }
            if (urun.Adet == 1)
            {
                btn.IsEnabled = false;                     
            }
        }
        private async void ToplamıHesapla()
        {   
            toplam = await App.Database.ToplamıHesapla();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (toplam==0)
            {
                await DisplayAlert("","Sepetinizde Ürün Bulunmamaktadır","Tamam");
            }
            else
            {
                if (GirisYaptıMı == 0)
                {
                    await DisplayAlert("", "Lütfen Önce Giriş Yapınız", "Tamam");
                    LoginPage.SepettenMiGeldin = 1;
                    await Shell.Current.GoToAsync($"//hesabim");
                }
                else
                {
                    await Navigation.PushAsync(new TeslimatAdresi(toplam));
                }
            }
        }
    }
}