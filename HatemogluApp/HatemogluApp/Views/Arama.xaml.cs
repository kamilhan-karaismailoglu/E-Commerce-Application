using HatemogluApp.ViewModels;
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
    public partial class Arama : ContentPage
    {
        readonly AramaViewModel AramaViewModel;
        public Arama()
        {
            AramaViewModel = new AramaViewModel();
            InitializeComponent();
            BindingContext = AramaViewModel;
        }
    }
}