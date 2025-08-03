using DeliveryApp.ViewModels;
using System;
using Xamarin.Forms;

namespace DeliveryApp
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
            Appearing += MainPage_Appearing; ;
        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            OnCheckPopup();
           // DataBaseConnecting();
        }

        private void OnCheckPopup()
        {
            viewModel.CheckThenDisplayPromt();
        }

        private void DataBaseConnecting()
        {
            viewModel.DataBaseConnecting();
        }

        private void ToSearch(object sender, EventArgs e)
        {
            viewModel.NavigateToSeaarchPage();
        }
    }
}
