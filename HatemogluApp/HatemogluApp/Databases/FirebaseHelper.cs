using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using HatemogluApp.Models;

namespace HatemogluApp
{
    class FirebaseHelper
    {
        static readonly FirebaseClient firebase = new FirebaseClient("https://hatemoglufirebase-7a308-default-rtdb.europe-west1.firebasedatabase.app/");
        static public async Task<List<Profil>> GetAllUsers()
        {
            return (await firebase
              .Child("users")
              .OnceAsync<Profil>()).Select(item => new Profil
              {
                  Isim = item.Object.Isim,
                  Soyisim = item.Object.Soyisim,
                  Telefon = item.Object.Telefon,
                  Email = item.Object.Email,
                  Sifre = item.Object.Sifre
              }).ToList();
        }
        static public async Task AddUser(string email, string sifre,string ad, string soyad, string telefon)
        {
            await firebase
              .Child("users")
              .PostAsync(new Profil() 
                            {   Email = email, 
                                Sifre = sifre,
                                Isim = ad,
                                Soyisim = soyad,
                                Telefon = telefon});
        }
        static public async Task<Profil> GetUser(string email)
        {
            var allUsers = await GetAllUsers();
            await firebase
              .Child("users")
              .OnceAsync<Profil>();
            return allUsers.Where(a => a.Email == email).FirstOrDefault();
        }
    }
}
