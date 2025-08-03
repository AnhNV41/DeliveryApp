using DeliveryApp.DataBase;
using DeliveryApp.DisplayModels;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
    public class MyCartPageViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<DisplayCategoryItemDetailModel> CategoryItems { get; private set; }
        public List<CartOrderModel> ListSortCartOrderItem { get; private set; }
        public List<OrderInFileModel> OrderInFileItems { get; set; }

        public List<OrderModel> BuyOrderItems { get; set; }
        public DisplayCategoryItemDetailModel selectedItem { get; set; }
        public DisplayCategoryItemDetailModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value == selectedItem)
                    return;
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public double TempPrice { get; set; }
        public string price { get; set; }
        public string Price
        {
            get { return price; }
            set
            {
                if (value == price)
                    return;
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public int TempTotalItem { get; set; }
        public string totalItem { get; set; }
        public string TotalItem
        {
            get { return totalItem; }
            set
            {
                if (value == totalItem)
                    return;
                totalItem = value;
                OnPropertyChanged("TotalItem");
            }
        }
        #endregion

        public MyCartPageViewModel() : this(DependencyService.Get<IFileHelper>())
        {
            CategoryItems = new ObservableCollection<DisplayCategoryItemDetailModel>();
        }

        public MyCartPageViewModel(IFileHelper fileHelper)
        {
            App.fileHelperProvider = fileHelper;
        }


        #region Command
        public Command DeleteTapCommand
        {
            get
            {
                return new Command((parameter) =>
                {
                    SelectedItem = parameter as DisplayCategoryItemDetailModel;
                    ShowPopup();
                });
            }
        }

        public Command ConfirmCommand
        {
            get
            {
                return new Command(() =>
                {
                    ShowConfirmPopup();
                });
            }
        }
        #endregion

        #region Function
        async void ShowPopup()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                bool ans = await App.Current.MainPage.DisplayAlert("Question?", "Do you want to delete", "Yes", "No");
                if (ans)
                {
                    DeleteItem();
                    SaveOrderToFile();
                }
            });
        }

        async void ShowConfirmPopup()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                bool ans = await App.Current.MainPage.DisplayAlert("Question?", "Do you want to buy", "Yes", "No");
                if (ans)
                {
                    ShowBuyPopup();
                }
            });
        }
        async void ShowBuyPopup()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                SaveDataBase();
                await App.Current.MainPage.DisplayAlert("Alert", "You have been successfully buy", "OK");
                NavigationDispatcher.Instance.NavigationPage("MainPage");
            });
        }

        public void DeleteItem()
        {
            foreach (var item in CategoryItems)
            {
                if (item == SelectedItem)
                {
                    CategoryItems.Remove(item);
                    OrderInFileItems.Remove(OrderInFileItems.Where(c => c.DetailCategoryItemID == item.ID).FirstOrDefault());
                    break;
                }
            }
            TotalPrice();
        }

        public async void TotalPrice()
        {
            TempPrice = 0;
            TempTotalItem = 0;
            foreach (var item in OrderInFileItems)
            {
                int quantity = Int32.Parse(item.Quantity);
                double price = Double.Parse(item.UnitPrice);
                TempPrice = TempPrice + price * quantity;
                Price = "$" + TempPrice.ToString();
                TempTotalItem = TempTotalItem + quantity;
                TotalItem = TempTotalItem.ToString() + " items";
            }
        }
        public async void SaveDataBase()
        {
            DataBaseManager database = await DataBaseManager.Instance;
            CartOrderModel sortitem = new CartOrderModel();
            sortitem.OrderTime = DateTime.Now;
            sortitem.TotalPrice= TempPrice;
            await database.SaveSortOrderItemAsync(sortitem);

            ListSortCartOrderItem = await database.GetMostRecentCartOrder();
            BuyOrderItems = new List<OrderModel>();
            foreach (var item in CategoryItems)
            {
                BuyOrderItems.Add(new OrderModel()
                {
                    OrderTime = System.DateTime.Now,
                    ImagePath = item.ImagePath,
                    CartOrderID = ListSortCartOrderItem.ElementAt(0).ID,
                });

            }
            database.SaveMultiOrderItemsAsync(BuyOrderItems);
            App.fileHelperProvider.DeleteFile(App.fileHelperProvider.GetAppDataPath());
            CategoryItems = new ObservableCollection<DisplayCategoryItemDetailModel>();
        }

        public void SaveOrderToFile()
        {
            List<string> list = new List<string>();
            if (CategoryItems.Count()>0)
            {
                foreach (var item in CategoryItems)
                {
                    list.Add(item.ID + "," + item.Title + "," + item.ImagePath + "," + item.UnitPrice + "," + item.Quantity);
                }
                String[] str = list.ToArray();
                App.fileHelperProvider.SaveTextInLine(str, App.fileHelperProvider.GetAppDataPath());
            }
            else
            {
                App.fileHelperProvider.DeleteFile(App.fileHelperProvider.GetAppDataPath());
            }
        }

        public void ReadFromFile()
        {
            if (App.fileHelperProvider.IsFileExisting(App.fileHelperProvider.GetAppDataPath()))
            {
                OrderInFileItems = App.fileHelperProvider.ReadTextInLine(App.fileHelperProvider.GetAppDataPath());
                foreach (var item in OrderInFileItems)
                {
                    CategoryItems.Add(new DisplayCategoryItemDetailModel
                    { ID = item.DetailCategoryItemID, ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly), ImagePath = item.ImagePath, Title = item.Title, UnitPrice = item.UnitPrice.ToString(), DisplayUnitPrice = '$' + item.UnitPrice.ToString(), Quantity = item.Quantity });
                }
                TotalPrice();
            }        
        }
        #endregion
    }
}
