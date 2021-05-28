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
    public partial class Kategoriler : ContentPage
    {
        readonly KategorilerViewModel KategorilerViewModel;
        public Kategoriler()
        {
            KategorilerViewModel = new KategorilerViewModel();
            InitializeComponent();
            BindingContext = KategorilerViewModel;
        }
    }
}