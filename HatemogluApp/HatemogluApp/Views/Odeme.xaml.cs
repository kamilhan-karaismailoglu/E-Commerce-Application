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
    public partial class Odeme : ContentPage
    {
        static double staticToplam;
        static readonly KrediKartı staticKrediKartı = new KrediKartı { };
        public Odeme()
        {
            InitializeComponent();
        }

        public Odeme(double toplam)
        {
            InitializeComponent();
            staticToplam = toplam;
            lbltoplam.Text = staticToplam.ToString();
            for (int i = 1; i < 13; i++)
            {
                if (i<10)
                {
                    pickerAy.Items.Add(0.ToString()+i.ToString());
                    continue;
                }
                pickerAy.Items.Add(i.ToString());
            }
            for (int i = 21; i <51 ; i++)
            {
                pickerYıl.Items.Add(i.ToString());
            }
        }
        private async void Button_Clicked_logo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//anasayfa");
        }

        private void PickerAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            staticKrediKartı.Ay = Convert.ToInt32(pickerAy.SelectedItem.ToString());
        }

        private void PickerYıl_SelectedIndexChanged(object sender, EventArgs e)
        {
            staticKrediKartı.Yıl = Convert.ToInt32(pickerYıl.SelectedItem.ToString());
        }

        private async void OdemeyiTamamla_Clicked(object sender, EventArgs e)
        {
            if (entryAdSoyad.Text==null || entryKartNumarası.Text == null || entryCvv.Text == null 
                || entryAdSoyad.Text == "" || entryKartNumarası.Text == "" || entryCvv.Text == ""
                || pickerAy.SelectedItem == null || pickerYıl.SelectedItem == null 
                || entryKartNumarası.Text.Length <16 || entryCvv.Text.Length<3 || entryAdSoyad.Text.Length < 3)
            {
                await DisplayAlert("","Lütfen Tüm Bilgileri Eksiksiz Girdiğinizden Emin Olun","Tamam");
            }
            else
            {
                var urunler = await App.Database.GetUrunsAsync();
                string siparis ="";
                for (int i = 0; i < urunler.Count; i++)
                {
                    siparis +="Ürün "+(i+1).ToString()+" : " +urunler[i].Baslik +" - Beden : "+ urunler[i].Beden + "\n";
                }
                
                staticKrediKartı.AdSoyad = entryAdSoyad.Text;
                staticKrediKartı.CVV = Convert.ToInt64(entryCvv.Text);
                staticKrediKartı.KartNumarası = entryKartNumarası.Text;
                await DisplayAlert("", "SİPARİŞ DETAYLARI : \n"+ siparis +"\n"+
                                    "SİPARİŞ TOPLAM TUTARI : "+ staticToplam.ToString()+ "₺" + "\n\n"+
                                    "SATIN ALAN KULLANICI : \n" + "İsim : "+ Hesap.user.Isim + "\n" + "Soyisim : " + Hesap.user.Soyisim + "\n" + "Mail : " + Hesap.user.Email+"\n"+ "Telefon : " + Hesap.user.Telefon+"\n" + "\n" +
                                    "TESLİMAT ADRESİ : \n" + SiparisOzeti.staticAdres.Baslık + "\n"+SiparisOzeti.staticAdres.Telefon + "\n" + SiparisOzeti.staticAdres.Ulke + " / " + SiparisOzeti.staticAdres.Sehir + " / " + SiparisOzeti.staticAdres.Ilce + "\n" + SiparisOzeti.staticAdres.TamAdres + "\n" + "\n" +
                                    "KART BİLGİLERİ : \n" + staticKrediKartı.AdSoyad + "\n" + staticKrediKartı.KartNumarası + "\n" + staticKrediKartı.Ay + "/" + staticKrediKartı.Yıl + "\n" + staticKrediKartı.CVV, "Tamam");
                
                await App.Database.DellAllUrunAsync();
                for (var counter = 1; counter < 3; counter++)
                {
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                }
                Sepetim.toplam = 0;
                await Navigation.PopAsync();
            }
        }
    }
}