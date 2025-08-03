using DeliveryApp.DataBase;
using DeliveryApp.DisplayModels;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
    public class StorePageViewModel : ViewModelBase
    {
        public List<StoreModel> ListStoreItem { get; private set; }
        public ObservableCollection<DisplayStoreModel> StoreItems { get; private set; }

        public StorePageViewModel()
        {
            DataBaseConnecting();
        }
        public async void DataBaseConnecting()
        {

            StoreItems = new ObservableCollection<DisplayStoreModel>();

            DataBaseManager database = await DataBaseManager.Instance;
            ListStoreItem = await database.GetStoreAsync();

            foreach (var item in ListStoreItem)
                StoreItems.Add(new DisplayStoreModel
                { ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly),StoreName=item.StoreName});
        }

        public Command BackCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigateToMainPage();
                });
            }
        }

        private void NavigateToMainPage()
        {
            NavigationDispatcher.Instance.NavigationPage("MainPage");
        }
    }
}
