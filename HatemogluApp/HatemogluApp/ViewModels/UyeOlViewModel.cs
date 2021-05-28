using Firebase.Auth;
using HatemogluApp.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace HatemogluApp.ViewModels
{
    public class UyeOlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static string Web_API_Key = "AIzaSyCrhGhMG_BQS_rwf4svmZ0_MEOF86aV5_M";

        private string name;
        private string surname;
        private string phone;
        private string mail;
        private string password;
        private string password2;
        private bool sozlesmeIsChecked = false;
        private Profil newuser;

        public Profil NewUser { get => newuser; set => newuser = value; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Surname"));
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
            }
        }
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Mail"));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public string Password2
        {
            get => password2;
            set
            {
                password2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password2"));
            }
        }
        public bool SozlesmeIsChecked
        {
            get => sozlesmeIsChecked;
            set
            {
                sozlesmeIsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SozlesmeIsChecked"));
            }
        }

        public Command LogoCommand
        {
            get
            {
                return new Command(AnasayfayaGit);
            }
        }
        public Command SepetCommand
        {
            get
            {
                return new Command(SepeteGit);
            }
        }
        public Command SozlesmeCommand
        {
            get
            {
                return new Command(Sozlesme);
            }
        }
        public Command KaydeButtonCommand
        {
            get
            {
                return new Command(Clicked_Kaydet);
            }
        }

        private async void AnasayfayaGit()
        {
            await AppShell.Current.GoToAsync($"//anasayfa");
        }
        private async void SepeteGit()
        {
            await AppShell.Current.GoToAsync($"//sepetim");
        }
        private async void Sozlesme()
        {
            string part1 = "ÜYELİK HAKKINDA\nMağazamıza üye olmak için Üye İşlemleri sayfamıza giderek ilgili bölümleri doldurmanız yeterlidir.Üye bilgilerinizi doğru ve eksiksiz doldurmanız iletişim ve ulaşım problemleri olasılığı açısından çok önemlidir.Ürün ve hizmetlerin çabuk ve sıhhatli ulaşması için lütfen dikkatle ve eksiksiz doldurunuz.Üye olmak oldukça basit ve hızlı bir işlemdir. Üye olmanız hiç bir yükümlülük altına girdiğinizi ifade etmez.Ancak alışveriş yapmadan önce Satış sözleşmesini dikkatle okuyunuz. Dilediğiniz zaman üyeliğinizi sonlandırma hakkına sahipsiniz.\n\n";
            string part2 = "ÜYELİK İPTALİ\nÜye dilediği zaman üyeliğini sonlandırma hakkına sahiptir.Üyeliğinizi sonlandırdıktan sonra sitemiz ile tüm ilişkiniz kesilmiş olacaktır.Üyeliğinizi sonlandırmak için üye girişi yaptıktan sonra iletişim bilgileri sayfamızdan talebinizi iletmelisiniz.\n\n";
            string part3 = "ÜYE GÜVENLİĞİ\nÜyenin güvenliği için mağazamızda her türlü önlem alınmıştır. Bu alınan önlemlerin yanında sizlerde üye bilgilerinizin güvenliğinden sorumlusunuz.Mağazamıza giriş için kullandığınız bilgilerinizi hiç kimse ile paylaşmayın, güvenli olduğundan emin olmadığınız bilgisayarlardan sisteme giriş yapmayın.Farklı AdresHer üye İçin Sipariş Sonlandırırken kendi kayıtlı adresi haricinde farklı adres girebileceği bir adres bölümü bulunmaktadır.Adres bölümünü arkadaşlarınıza hediye gönderirken kullanabileceğiniz gibi, farklı adreslerde olduğunuz dönemlerde kullanabilmeniz için düşünülmüştür.Örneğin: Çalıştığınız şirketin farklı şubelerinde bulunacağınız dönemlerde veya yazlıkta kaldığınız dönemlerde. Yâda faturanızın size siparişinizin bir arkadaşınıza ulaşmasını istiyorsanız\n\n";
            string part4 = "ÜRÜN YORUMLARI\nHer üye ürünlere yorum yazabilir.Bilgilerinizi ve tecrübelerinizi diğer kullanıcılarla paylaştıkça, alışveriş daha keyifli ve bilinçli olacaktır.Müşteri yorumları tarafsız ve tecrübeye dayalı olacağı için daha bilinçli alışveriş ortamı doğacaktır.Ürün yorumu yazarken dikkat etmeniz gerekenler: Genel ahlak kuralları çerçevesinde, diğer kullanıcılara ve ürünün üreticisine saygılı yorumlar yazmaya özen gösterin.Yorumlar incelenerek uygun görülmeyen yorumlar sistemden silinmektedir.\n";
            await App.Current.MainPage.DisplayAlert("Üyelik Sözleşmesi", part1 + part2 + part3 + part4, "Anladım");
        }
        private async void Clicked_Kaydet()
        {
            if (SozlesmeIsChecked)
            {
                if (Name != null && Surname != null && Phone != null && Mail != null && Password != null && Password2 != null)
                {
                    if (7 < Password.Length)
                    {
                        if (Password == Password2)
                        {
                            if (Email_Format_Kontrol(Mail))
                            {
                                NewUser = new Profil
                                {
                                    Isim = Name,
                                    Soyisim = Surname,
                                    Telefon = Phone,
                                    Email = Mail,
                                    Sifre = Password
                                };
                                Kaydet(NewUser);
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Bilgilerinizi Kontrol Edin", "Girilen Mail Adresinin Doğru Oldunundan Emin olun, Lütfen Tekrar Deneyin", "Tamam");
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Bilgilerinizi Kontrol Edin", "Girilen Şifreler Uyuşmuyor, Lütfen Tekrar Deneyin", "Tamam");
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Bilgilerinizi Kontrol Edin", "Şifreniz En az 8 Karakter Olmalıdır, Lütfen Tekrar Deneyin", "Tamam");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Bilgilerinizi Kontrol Edin", "Lütfen Tüm Alanları Doğru Şekilde Doldurduğunuzdan Emin Olun", "Tamam");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Sözleşmeyi Kabul Edin", "Lütfen Sözleşmeyi Okuyup Onayladığınıza Dair Seçeneği Kabul Edin", "Tamam");
            }
        }
        public static bool Email_Format_Kontrol(string email)
        {
            try
            {
                MailAddress DogruMail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async void Kaydet(Profil NewUser)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Web_API_Key));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(NewUser.Email, NewUser.Sifre);

                await FirebaseHelper.AddUser(NewUser.Email, NewUser.Sifre, NewUser.Isim, NewUser.Soyisim, NewUser.Telefon);

                await App.Current.MainPage.DisplayAlert("Kayıt Başarılı", "Lütfen Giriş Yapın", "Tamam");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Kayıt Başarısız", "Lütfen Mail Adresinizin Daha Önce Kullanılmadığından Emin Olunuz", "Tamam");
            }
        }
    }
}
