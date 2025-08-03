using DeliveryApp.DisplayModels;
using DeliveryApp.Models;
using DeliveryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCartPage : ContentPage
    {
        MyCartPageViewModel myCartPageViewModel;
        public MyCartPage()
        {
            InitializeComponent();
            myCartPageViewModel = new MyCartPageViewModel();
            BindingContext = myCartPageViewModel;
            Appearing += MyCartPage_Appearing;
            Disappearing += MyCartPage_Disappearing;
        }

        private void MyCartPage_Appearing(object sender, EventArgs e)
        {
            myCartPageViewModel.ReadFromFile();
        }

        private void MyCartPage_Disappearing(object sender, EventArgs e)
        {
            myCartPageViewModel.SaveOrderToFile();
        }
    }
}