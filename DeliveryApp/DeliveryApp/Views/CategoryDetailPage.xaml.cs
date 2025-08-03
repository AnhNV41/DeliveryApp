using DeliveryApp.Helper;
using DeliveryApp.Models;
using DeliveryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailPage : ContentPage
    {
        private CategoryDetailPageViewModel categoryDetailPageViewModel;
        public CategoryDetailPage(string par)
        {
            InitializeComponent();
            categoryDetailPageViewModel = new CategoryDetailPageViewModel(par);
            BindingContext = categoryDetailPageViewModel;
            Appearing += CategoryDetailPage_Appearing;
            Disappearing += CategoryDetailPage_Disappearing;
        }

        private void CategoryDetailPage_Disappearing(object sender, EventArgs e)
        {
            categoryDetailPageViewModel.SaveOrderToFile();
        }

        private void CategoryDetailPage_Appearing(object sender, EventArgs e)
        {
            categoryDetailPageViewModel.IsContinueWithCurrentOrder();
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                NavigationDispatcher.Instance.NavigationPage("MainPage");
            });
            return true;
        }

        //private void FillterAction(object sender, EventArgs e)
        //{
        //    MainThread.BeginInvokeOnMainThread(async () =>
        //    {
        //        string action = await App.Current.MainPage.DisplayActionSheet("Option Filter", "Cancel", null, "Ascending", "Descending", "Liked", "Clear filter");
        //    });
        //}
    }
}