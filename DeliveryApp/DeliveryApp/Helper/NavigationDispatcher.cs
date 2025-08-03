using DeliveryApp.DisplayModels;
using DeliveryApp.Models;
using DeliveryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DeliveryApp.Helper
{
    public class NavigationDispatcher
    {
        private static NavigationDispatcher _instance;

        private INavigation _navigation;

        public static NavigationDispatcher Instance =>
                      _instance ?? (_instance = new NavigationDispatcher());

        public INavigation Navigation =>
                     _navigation ?? throw new Exception("NavigationDispatcher is not initialized");

        public void Initialize(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void NavigationPage(string page, string par1 = "", string par2 = "", string par3 = "")
        {
            switch (page)
            {
                case "MainPage":
                    NavigationDispatcher.Instance.Navigation.PushAsync(new MainPage());
                    break;

                case "CategoryDetailPage":
                    NavigationDispatcher.Instance.Navigation.PushAsync(new CategoryDetailPage(par1));
                    break;

                case "MyCartPage":
                    NavigationDispatcher.Instance.Navigation.PushAsync(new MyCartPage());
                    break;
                case "RecentOrderPage":
                    NavigationDispatcher.Instance.Navigation.PushAsync(new RecentPage());
                    break;
                case "StorePage":
                    NavigationDispatcher.Instance.Navigation.PushAsync(new StorePage());
                    break;
                case "Search":
                    NavigationDispatcher.Instance.Navigation.PushAsync(new Search(par1, par2, par3));
                    break;
            }
        }
    }
}
