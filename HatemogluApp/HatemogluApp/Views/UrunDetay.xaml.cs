using HatemogluApp.Models;
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
    public partial class UrunDetay : ContentPage
    {
        static SepetUrun kontrolstatic = null;
        static SepetUrun eklenecekUrun;
        public UrunDetay()
        {
            InitializeComponent();
        }
        public UrunDetay(string tur,string baslik,string fiyat,string eskifiyat, string indirim, string resim,string ozellikler)
        {
            InitializeComponent();

            Urun seciliurun = new Urun { Tur= tur ,Baslik=baslik,Fiyat=fiyat,Eskifiyat=eskifiyat,Indirim=indirim,Resim=resim,Ozellikler=ozellikler };

            List<Urun> UrunlerList = new List<Urun> { seciliurun };

            ImgResim.Source = seciliurun.Resim;
            title.Text = seciliurun.Baslik;
            LabelIndirim.Text = seciliurun.Indirim;
            LabelEskifiyat.Text = seciliurun.Eskifiyat;
            LabelFiyat.Text = seciliurun.Fiyat;

            var bedenler = new List<string> { };
            if (seciliurun.Tur == "Slim Fit Pantolonlar" || seciliurun.Tur == "Klasik Pantolonlar" || seciliurun.Tur == "Kot Pantolonlar")
            {
                bedenler = new List<string>
                {
                    "29","30","31","32","33","34","35","36"
                };
            }
            else
            {
                bedenler = new List<string>
                {
                    "S","M","L","XL"
                };
            }
            
            foreach (var item in bedenler)
            {
                BedenPicker.Items.Add(item);
            }

            LabelOzellikler.Text = seciliurun.Ozellikler;
            LabelIndirim2.Text = seciliurun.Indirim;
            LabelEskifiyat2.Text = seciliurun.Eskifiyat;
            LabelFiyat2.Text = seciliurun.Fiyat;
            seciliurun.Beden = SecilenBeden?.Text;
        }
        private async void Clicked_Sepete_Ekle(object sender, EventArgs e)
        {
            string ekleBeden = SecilenBeden?.Text;

            if (ekleBeden==null)
            {
                await DisplayAlert("","Lütfen Beden Seçin","Anladım");
            }
            else
            {
                string EkleResim1 = ImgResim.Source.ToString();
                char ayrac = ':';
                string[] EkleResim2 = EkleResim1.Split(ayrac);
                string EkleResim3 = EkleResim2[1]+":"+EkleResim2[2];
                char ayrac2 = ' ';
                string[] EkleResim4 = EkleResim3.Split(ayrac2);
                string EkleResim = EkleResim4[1];

                eklenecekUrun = new SepetUrun
                {
                    Baslik = title.Text,
                    Fiyat = LabelFiyat.Text,
                    Indirim = LabelIndirim.Text,
                    Eskifiyat = LabelEskifiyat.Text,
                    Resim = EkleResim,
                    Beden = ekleBeden,
                    Adet = 0
                };

                eklenecekUrun.Adet += 1; 

                kontrolstatic = await App.Database.GetNameAndBedenSepetUrunAsync(eklenecekUrun.Baslik,eklenecekUrun.Beden);
                

                if(kontrolstatic == null)
                {
                    await App.Database.SaveUrunAsync(eklenecekUrun);
                    await DisplayAlert("", "Ürün Sepetinize Eklendi", "Tamam");
                    await Navigation.PushAsync(new Sepetim(eklenecekUrun.Toplam));
                }
                else
                {
                    await DisplayAlert("Ürün Sepetinizde Mevcut", "Adet arttırımını Sepetinizden Yapabilirsiniz", "Tamam");
                }
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

        private void BedenPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string beden = BedenPicker.SelectedItem.ToString();
            SecilenBeden.Text = beden;
        }
    }
}