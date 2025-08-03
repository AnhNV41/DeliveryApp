using DeliveryApp.Constants;
using DeliveryApp.DataBase;
using DeliveryApp.DataProvider;
using DeliveryApp.DisplayModels;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties
        public List<CategoryItemModel> ListCategoryItem { get; private set; }
        public List<OrderModel> ListOrderItem { get; private set; }
        public List<CartOrderModel> ListSortOrderItem { get; private set; }
        public List<StoreModel> ListStoreItem { get; private set; }


        public ObservableCollection<DisplayCategoryItemModel> CategoryItems { get; private set; }
        public ObservableCollection<DisplayOrderModel> OrderItems { get; private set; }
        public ObservableCollection<DisplayStoreModel> StoreItems { get; private set; }


        public DisplayCategoryItemModel _selectedItem;
        public DisplayCategoryItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem)
                    return;
                _selectedItem = value;
                NavigateToCategoryDetailPage(SelectedItem.Title);
                OnPropertyChanged("SelectedItem");
            }
        }

        public string _timeOrder;
        public string TimeOrder
        {
            get { return _timeOrder; }
            set
            {
                if (value == _timeOrder)
                    return;
                _timeOrder = value;
                OnPropertyChanged("TimeOrder");
            }
        }

        public string _totalPrice;
        public string TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (value == _totalPrice)
                    return;
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        public string location { get; set; }
        public string Location
        {
            get { return location; }
            set
            {
                if (value == location)
                    return;
                location = value;

                OnPropertyChanged("Location");
            }
        }
        public DisplayCategoryItemModel temp;

        private ICategoryItemDataProvider CategoryItemData;
        private ICategoryItemDetailDataProvider CategoryItemDetailData;
        private IOrderDataProvider orderDataProvider;
        private IStoreDataProvider storedataProvider;
        #endregion

        public MainPageViewModel() : this(DependencyService.Get<ICategoryItemDataProvider>(), DependencyService.Get<IOrderDataProvider>(), DependencyService.Get<ICategoryItemDetailDataProvider>(), DependencyService.Get<IStoreDataProvider>())
        {
            CategoryItems = new ObservableCollection<DisplayCategoryItemModel>();
            OrderItems = new ObservableCollection<DisplayOrderModel>();
            StoreItems = new ObservableCollection<DisplayStoreModel>();

            DataBaseConnecting();
            Location = Preferences.Get("my_key", "default_value");
        }

        public MainPageViewModel(ICategoryItemDataProvider parCategoryItemData, IOrderDataProvider orderdata, ICategoryItemDetailDataProvider parCategoryItemDetailData, IStoreDataProvider storedata)
        {
            CategoryItemData = parCategoryItemData;
            CategoryItemDetailData = parCategoryItemDetailData;
            orderDataProvider = orderdata;
            storedataProvider = storedata;

            if (!IsExist())
            {
                CreateDataBase(CategoryItemData.ProvideInfor(), orderDataProvider.ProvideInfor(), CategoryItemDetailData.ProvideInfor(), storedataProvider.ProvideInfor());
            }
        }

        #region Command
        public Command TapCommand
        {
            get
            {
                return new Command((parameter) =>
                {
                    if (parameter.Equals(CategoryItems.ElementAt(0)))
                        NavigateToCategoryDetailPage(SelectedItem.Title);
                });
            }
        }

        public Command StoreTapCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigateToCategoryStorePage();
                });
            }
        }

        public Command RecentTapCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigateToRecentOrderPage();
                });
            }
        }

        public Command CartTapCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigateToMyCartPage();
                });
            }
        }
        #endregion

        #region Function
        private void NavigateToRecentOrderPage()
        {
            NavigationDispatcher.Instance.NavigationPage("RecentOrderPage");
        }

        void NavigateToCategoryDetailPage(string par)
        {
            NavigationDispatcher.Instance.NavigationPage("CategoryDetailPage", par);
        }

        void NavigateToCategoryStorePage()
        {
            NavigationDispatcher.Instance.NavigationPage("StorePage");
        }

        public void NavigateToSeaarchPage()
        {
            NavigationDispatcher.Instance.NavigationPage("Search");
        }

        public bool IsExist()
        {
            return File.Exists(DataBaseConstant.DatabasePath);
        }

        public async void CreateDataBase(List<CategoryItemModel> temp, List<OrderModel> tempOrder, List<CategoryItemDetailModel> tempDetail, List<StoreModel> tempStore)
        {
            DataBaseManager database = await DataBaseManager.Instance;
            database.SaveMultiItemsAsync(temp);
            CartOrderModel _temp = new CartOrderModel() { OrderTime = DateTime.Now };
            await database.SaveSortOrderItemAsync(_temp);
             database.SaveMultiOrderItemsAsync(tempOrder);
             database.SaveMultiDetailItemsAsync(tempDetail);
             database.SaveMultiStoreItemsAsync(tempStore);
        }

        public void CheckThenDisplayPromt()
        {
            if (Location == "default_value")
                DisplayPrompt();
        }

        public async void DataBaseConnecting()
        {
         
            DataBaseManager database = await DataBaseManager.Instance;

            ListCategoryItem = await database.GetCategoryAsync();
            ListSortOrderItem = await database.GetMostRecentCartOrder();
            ListOrderItem = await database.GetMostRecentOrderDetailCategorybyOrderID(ListSortOrderItem.ElementAt(0).ID.ToString());
            ListStoreItem = await database.GetStoreAsync();

            TimeOrder = ListSortOrderItem.ElementAt(0).OrderTime.ToString();
            TotalPrice = "Order for "+ListSortOrderItem.ElementAt(0).TotalPrice.ToString()+"$";
            if (ListCategoryItem != null)
            {
                ColorTypeConverter converter = new ColorTypeConverter();
                CategoryItems.Clear();
                foreach (var item in ListCategoryItem)
                {
                    CategoryItems.Add(new DisplayCategoryItemModel
                    { ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly), Title = item.CategoryTitle, ColorCode = (Color)(converter.ConvertFromInvariantString(item.ColorCode)) });
                }                 
            }

            if (ListOrderItem !=null)
            {
                OrderItems.Clear();
                foreach (var item in ListOrderItem)
                {
                    OrderItems.Add(new DisplayOrderModel
                    { ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly) });
                }
                 
            }

            if (ListStoreItem !=null)
            {
                StoreItems.Clear();
                int count = 0;
                foreach (var item in ListStoreItem)
                {
                    if (count == 4)
                        break;
                    StoreItems.Add(new DisplayStoreModel
                    { ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly) });
                    count++;
                }
            }          
        }

        public async void DisplayPrompt()
        {
            string result = await App.Current.MainPage.DisplayPromptAsync("Location", "What's your location?");
            Location = result;
            Preferences.Set("my_key", result);
        }

        private void NavigateToMyCartPage()
        {
            NavigationDispatcher.Instance.NavigationPage("MyCartPage", "", "");
        }
        #endregion

    }
}
