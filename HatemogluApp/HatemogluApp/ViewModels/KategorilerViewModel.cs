using HatemogluApp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatemogluApp.ViewModels
{
    public class KategorilerViewModel : BaseViewModel
    {
        public KategorilerViewModel()
        {

        }

        public Command LogoCommand
        {
            get
            {
                return new Command(logo);
            }
        }
        public Command SepetCommand
        {
            get
            {
                return new Command(sepetim);
            }
        }
        public Command GomlekCommand
        {
            get
            {
                return new Command(gomlek);
            }
        }
        public Command KazakCommand
        {
            get
            {
                return new Command(kazak);
            }
        }
        public Command TisortCommand
        {
            get
            {
                return new Command(tisort);
            }
        }
        public Command PantolonCommand
        {
            get
            {
                return new Command(pantolon);
            }
        }
        public Command CeketCommand
        {
            get
            {
                return new Command(ceket);
            }
        }

        private async void logo()
        {
            await AppShell.Current.GoToAsync($"//anasayfa");
        }
        private async void sepetim()
        {
            await AppShell.Current.GoToAsync($"//sepetim");
        }
        private async void gomlek()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AltKategoriler("gomlek"));
        }
        private async void kazak()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AltKategoriler("kazak"));
        }
        private async void tisort()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AltKategoriler("tisort"));
        }
        private async void pantolon()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AltKategoriler("pantolon"));
        }
        private async void ceket()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AltKategoriler("ceket"));
        }
    }
}
