using DeliveryApp.DataBase;
using DeliveryApp.DisplayModels;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
    public class RecentPageViewModel : ViewModelBase
    {
        #region Properties
        public List<OrderModel> ListOrderItem { get; private set; }
        public List<CartOrderModel> ListCartOrderItem { get; private set; }
        public ObservableCollection<DisplayOrderModel> OrderItems { get; private set; }

        public ObservableCollection<DisplayCartOrderModel> CartOrderItems { get; set; }
        #endregion

        public RecentPageViewModel()
        {
            CartOrderItems = new ObservableCollection<DisplayCartOrderModel>();
            DataBaseConnecting();

        }
        public async void DataBaseConnecting()
        {
            OrderItems = new ObservableCollection<DisplayOrderModel>();
            double Price;
            DataBaseManager database = await DataBaseManager.Instance;
            ListCartOrderItem = await database.GetMostRecentCartOrder();
            foreach (var item in ListCartOrderItem)
            {
                Price = 0;
                OrderItems = new ObservableCollection<DisplayOrderModel>();
                ListOrderItem = await database.GetMostRecentOrderDetailCategorybyOrderID(item.ID.ToString());
                if (ListOrderItem.Count > 0)
                {
                    foreach (var _item in ListOrderItem)
                    {
                        OrderItems.Add(new DisplayOrderModel
                        { ImageSource = ImageSource.FromResource(_item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly),Quantity=_item.Quantity.ToString()});
                    }
                    Price = item.TotalPrice;
                    CartOrderItems.Add(new DisplayCartOrderModel()
                    {
                        Price = Price.ToString()+"$",
                        Time = item.OrderTime.ToString(),
                        OrderItems = OrderItems
                    }) ;
                }
            }
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
