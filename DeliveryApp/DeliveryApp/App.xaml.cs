using DeliveryApp.Constants;
using DeliveryApp.DataBase;
using DeliveryApp.DataProvider;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp
{
    public partial class App : Application
    {
        public static IFileHelper fileHelperProvider;

        public App()
        {
            InitializeComponent();
            RegisterDependencies();

            MainPage = new NavigationPage(new MainPage());
            NavigationDispatcher.Instance.Initialize(MainPage.Navigation);
        }

        public void RegisterDependencies()
        {
            DependencyService.Register<ICategoryItemDataProvider, DataProviderInitialize>();
            DependencyService.Register<IOrderDataProvider, ModelDataProviderInitialize>();
            DependencyService.Register<ICategoryItemDetailDataProvider, DetailModelDataProviderInitialize>();
            DependencyService.Register<IStoreDataProvider, StoreModelDataProviderInitialize>();
            DependencyService.Register<IFileHelper, FileProvider>();
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
