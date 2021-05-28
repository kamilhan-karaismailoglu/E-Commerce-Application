using HatemogluApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HatemogluApp.Databases;
using System.IO;

namespace HatemogluApp
{
    public partial class App : Application
    {
        private static SepetDataBase database;
        public static SepetDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SepetDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SepetDb.db3"));
                }
                return database;
            }
        }
        
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
