using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HatemogluApp.Models;
using HatemogluApp.ViewModels;

namespace HatemogluApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiltrelePopup : PopupPage
    {
        static int acıkMı1 = 0;
        static int acıkMı2 = 0;
        static int acıkMı3 = 0;
        static List<Urun> staticList = new List<Urun> { };
        static int RenkSecildi = 0;
        static List<string> SeciliRenkler = new List<string> { };

        public FiltrelePopup(object gelenliste)
        {
            InitializeComponent();
            staticList = gelenliste as List<Urun>;
        }
        [Obsolete]
        private async void close_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
        private void btn1_Clicked(object sender, EventArgs e)
        {
            if (acıkMı1 == 0)
            {
                entries1.IsVisible = true;
                ımg1.Source = "icon_up.png";
                sep1.IsVisible = false;
                acıkMı1 = 1;
            }
            else if (acıkMı1 == 1)
            {
                entries1.IsVisible = false;
                ımg1.Source = "icon_down.png";
                sep1.IsVisible = true;
                acıkMı1 = 0;
            }
        }
        private void btn2_Clicked(object sender, EventArgs e)
        {
            if (acıkMı2 == 0)
            {
                entries2.IsVisible = true;
                ımg2.Source = "icon_up.png";
                sep2.IsVisible = false;
                acıkMı2 = 1;
            }
            else if (acıkMı2 == 1)
            {
                entries2.IsVisible = false;
                ımg2.Source = "icon_down.png";
                sep2.IsVisible = true;
                acıkMı2 = 0;
            }
        }
        private void btn3_Clicked(object sender, EventArgs e)
        {
            if (acıkMı3 == 0)
            {
                entries3.IsVisible = true;
                ımg3.Source = "icon_up.png";
                sep3.IsVisible = false;
                acıkMı3 = 1;
            }
            else if (acıkMı3 == 1)
            {
                entries3.IsVisible = false;
                ımg3.Source = "icon_down.png";
                sep3.IsVisible = true;
                acıkMı3 = 0;
            }
        }
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            min.Text = null;
            max.Text = null;
            min2.Text = null;
            max2.Text = null;

            renk1.Opacity = 1;
            renk1.ImageSource = null;
            renk2.Opacity = 1;
            renk2.ImageSource = null;
            renk3.Opacity = 1;
            renk3.ImageSource = null;
            renk4.Opacity = 1;
            renk4.ImageSource = null;
            renk5.Opacity = 1;
            renk5.ImageSource = null;
            renk6.Opacity = 1;
            renk6.ImageSource = null;
            renk7.Opacity = 1;
            renk7.ImageSource = null;
            renk8.Opacity = 1;
            renk8.ImageSource = null;
            renk9.Opacity = 1;
            renk9.ImageSource = null;
            renk10.Opacity = 1;
            renk10.ImageSource = null;
            renk11.Opacity = 1;
            renk11.ImageSource = null;
            renk12.Opacity = 1;
            renk12.ImageSource = null;
            renk13.Opacity = 1;
            renk13.ImageSource = null;
            renk14.Opacity = 1;
            renk14.ImageSource = null;
            renk15.Opacity = 1;
            renk15.ImageSource = null;
            renk16.Opacity = 1;
            renk16.ImageSource = null;
            renk17.Opacity = 1;
            renk17.ImageSource = null;
            renk18.Opacity = 1;
            renk18.ImageSource = null;
        }

        [Obsolete]
        private async void BtnGo_Clicked(object sender, EventArgs e)
        {
            List<Urun> yeniliste = new List<Urun> { };

            int sayac = 0;
            double fiyatmin = 0;
            double fiyatmax = 0;

            if (min.Text != "")
            {
                fiyatmin = Convert.ToDouble(min.Text);
            }
            if (max.Text != "")
            {
                fiyatmax = Convert.ToDouble(max.Text);
            }
            if (max.Text == "")
            {
                fiyatmax = 0.0;
            }
            if (min.Text == "")
            {
                fiyatmin = 0.0;
            }

            if (fiyatmax != 0 || fiyatmin != 0)
            {
                if (fiyatmax != 0 && fiyatmin >= fiyatmax)
                {
                    await DisplayAlert("", "Fiyat Aralığında Minimum Değer Maximum Değerden Büyük Veya Eşit Olamaz", "Tamam");
                }
                else
                {
                    if (fiyatmax != 0)
                    {
                        foreach (var item in staticList)
                        {
                            if (Convert.ToDouble(item.Fiyat) > fiyatmin && Convert.ToDouble(item.Fiyat) < fiyatmax)
                            {
                                yeniliste.Add(item);
                                sayac++;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in staticList)
                        {
                            if (Convert.ToDouble(item.Fiyat) > fiyatmin)
                            {
                                yeniliste.Add(item);
                                sayac++;
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            int MinIndirim = 0;
            int MaxIndirim = 0;

            if (min2.Text != "")
            {
                MinIndirim = Convert.ToInt32(min2.Text);
            }
            if (max2.Text != "")
            {
                MaxIndirim = Convert.ToInt32(max2.Text);
            }
            if (max2.Text == "")
            {
                MaxIndirim = 0;
            }
            if (min2.Text == "")
            {
                MinIndirim = 0;
            }

            if (MaxIndirim != 0 || MinIndirim != 0)
            {
                if (sayac == 0)
                {
                    if (MaxIndirim > 100 || MinIndirim > 100)
                    {
                        await DisplayAlert("", "İndirim Aralığı Minimum 0 Maximum 100 Olabilir", "Tamam");
                    }
                    else
                    {
                        if (MaxIndirim != 0 && MinIndirim >= MaxIndirim)
                        {
                            await DisplayAlert("", "İndirim Aralığında Minimum Değer Maximum Değerden Büyük Veya Eşit Olamaz", "Tamam");
                        }
                        else
                        {
                            if (MaxIndirim != 0)
                            {
                                foreach (var item in staticList)
                                {
                                    char ayrac = '%';
                                    string[] parcalar = item.Indirim.Split(ayrac);
                                    int indirim = Convert.ToInt32(parcalar[1]);

                                    if (indirim > MinIndirim && indirim < MaxIndirim)
                                    {
                                        yeniliste.Add(item);
                                        sayac = 1;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in staticList)
                                {
                                    char ayrac = '%';
                                    string[] parcalar = item.Indirim.Split(ayrac);
                                    int indirim = Convert.ToInt32(parcalar[1]);

                                    if (indirim > MinIndirim)
                                    {
                                        yeniliste.Add(item);
                                        sayac = 1;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    if (MaxIndirim > 100 || MinIndirim > 100)
                    {
                        await DisplayAlert("", "İndirim Aralığı Minimum 0 Maximum 100 Olabilir", "Tamam");
                    }
                    else
                    {
                        if (MaxIndirim != 0 && MinIndirim >= MaxIndirim)
                        {
                            await DisplayAlert("", "İndirim Aralığında Minimum Değer Maximum Değerden Büyük Veya Eşit Olamaz", "Tamam");
                        }
                        else
                        {
                            List<Urun> yeniliste2 = new List<Urun> { };

                            if (MaxIndirim != 0)
                            {
                                foreach (var item in yeniliste)
                                {
                                    char ayrac = '%';
                                    string[] parcalar = item.Indirim.Split(ayrac);
                                    int indirim = Convert.ToInt32(parcalar[1]);

                                    if (indirim > MinIndirim && indirim < MaxIndirim)
                                    {
                                        yeniliste2.Add(item);
                                        sayac = 1;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in yeniliste)
                                {
                                    char ayrac = '%';
                                    string[] parcalar = item.Indirim.Split(ayrac);
                                    int indirim = Convert.ToInt32(parcalar[1]);

                                    if (indirim > MinIndirim)
                                    {
                                        yeniliste2.Add(item);
                                        sayac = 1;
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            yeniliste = yeniliste2;
                        }
                    }

                }
            }

            if (RenkSecildi != 0)
            {
                if (fiyatmax == 0 && fiyatmin == 0 && MinIndirim == 0 && MaxIndirim == 0)
                {
                    foreach (var item in staticList)
                    {
                        foreach (var renk in SeciliRenkler)
                        {
                            int sonuc = item.Baslik.IndexOf(renk);
                            if (sonuc > 0)
                            {
                                yeniliste.Add(item);
                                sayac = 1;
                            }
                        }
                    }

                }
                else
                {
                    List<Urun> yeniliste2 = new List<Urun> { };

                    foreach (var item in yeniliste)
                    {
                        foreach (var renk in SeciliRenkler)
                        {
                            int sonuc = item.Baslik.IndexOf(renk);
                            if (sonuc > 0)
                            {
                                yeniliste2.Add(item);
                                sayac = 1;
                            }
                        }
                    }
                    yeniliste = yeniliste2;
                }
            }

            if (sayac != 0)
            {
                await Navigation.PushAsync(new Urunler(yeniliste));
                SeciliRenkler.Clear();
                sayac = 0;
                RenkSecildi = 0;
                await PopupNavigation.PopAsync(true);
            }
            else
            {
                await DisplayAlert("", "Aradığınız Aralıkta Ürün Bulunamadı", "Tamam");
                SeciliRenkler.Clear();
                RenkSecildi = 0;
                await PopupNavigation.PopAsync(true);
            }
        }

        private void ButtonRenk_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Opacity == 1)
            {
                btn.Opacity = 0.7;
                btn.ImageSource = "icon_selected.png";
                char ayrac = ' ';
                string[] parcalar = btn.Text.Split(ayrac);
                SeciliRenkler.Add(parcalar[1]);
                RenkSecildi++;
            }
            else
            {
                btn.Opacity = 1;
                btn.ImageSource = null;
                char ayrac = ' ';
                string[] parcalar = btn.Text.Split(ayrac);
                SeciliRenkler.Remove(parcalar[1]);
                RenkSecildi--;
            }
        }

    }
}