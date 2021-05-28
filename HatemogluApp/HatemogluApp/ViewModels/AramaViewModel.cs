using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatemogluApp.ViewModels
{
    class AramaViewModel : BaseViewModel
    {
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

        private async void logo()
        {
            await AppShell.Current.GoToAsync($"//anasayfa");
        }
        private async void sepetim()
        {
            await AppShell.Current.GoToAsync($"//sepetim");
        }
    }
}
