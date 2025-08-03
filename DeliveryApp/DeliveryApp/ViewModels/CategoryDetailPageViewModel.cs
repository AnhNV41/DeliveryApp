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
    public class CategoryDetailPageViewModel : ViewModelBase
    {
        #region Properties
        public bool CheckFile = false;
        public List<OrderInFileModel> OrderInFileItems { get; set; }
        public List<CategoryItemDetailModel> ListCategoryItem { get; private set; }
        public List<DisplayOrderModel> ListOrder { get; private set; }
        public ObservableCollection<DisplayCategoryItemDetailModel> CategoryItems { get; private set; }

        public int _totalPrice;
        public int TotalPrice
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

        public string pageTitle;
        public string PageTitle
        {
            get { return pageTitle; }
            set
            {
                if (value == pageTitle)
                    return;
                pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

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

        public DisplayCategoryItemDetailModel fillterSelectedItem { get; set; }
        public DisplayCategoryItemDetailModel FillterSelectedItem
        {
            get { return fillterSelectedItem; }
            set
            {
                if (value == fillterSelectedItem)
                    return;
                fillterSelectedItem = value;
                NavigationDispatcher.Instance.NavigationPage("Search", "", "", fillterSelectedItem.Title);
                OnPropertyChanged("FillterSelectedItem");
            }
        }
        #endregion

        public CategoryDetailPageViewModel(string par) : this(DependencyService.Get<IFileHelper>())
        {
            PageTitle = par;
            ListOrder = new List<DisplayOrderModel>();
            OrderInFileItems = new List<OrderInFileModel>();

            CategoryItems = new ObservableCollection<DisplayCategoryItemDetailModel>();
            DataBaseConnecting(par);
        }

        public CategoryDetailPageViewModel(IFileHelper fileHelper)
        {
            App.fileHelperProvider = fileHelper;
        }

        #region Command
        public Command FilterCommand
        {
            get
            {
                return new Command(() =>
                {
                    ShowPopup();
                });
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

        public Command PlusCommand
        {
            get
            {
                return new Command(() =>
                {
                    PlusItem();
                });
            }
        }

        public Command SubtractCommand
        {
            get
            {
                return new Command(() =>
                {
                    SuntractItem();
                });
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigationDispatcher.Instance.NavigationPage("Search");
                });
            }
        }
        #endregion

        #region Function
        string action;

        async void ShowPopup()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                action = await App.Current.MainPage.DisplayActionSheet("Option Filter", "Cancel", null, "Ascending", "Descending", "Liked", "Clear filter");
                if (action != "Cancel")
                {
                    if (action == "Ascending")
                    {
                        NavigationDispatcher.Instance.NavigationPage("Search", PageTitle, "ASC");
                    }
                    else if (action == "Descending")
                    {
                        NavigationDispatcher.Instance.NavigationPage("Search", PageTitle, "DESC");
                    }
                    else
                        NavigationDispatcher.Instance.NavigationPage("Search", PageTitle, action);
                }
            });
        }

        public async void DataBaseConnecting(string par)
        {
            DataBaseManager database = await DataBaseManager.Instance;

            ListCategoryItem = await database.GetDetailCategoryByCategoryCode(par);
            ColorTypeConverter converter = new ColorTypeConverter();
            foreach (var item in ListCategoryItem)
                CategoryItems.Add(new DisplayCategoryItemDetailModel
                { ID = item.ID.ToString(), ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly), ImagePath = item.ImagePath, Title = item.Title, ColorCode = (Color)(converter.ConvertFromInvariantString(item.ColorCode)),DisplayUnitPrice='$'+item.UnitPrice.ToString(), UnitPrice = item.UnitPrice.ToString(),Like=item.Like });
        }

        private void PlusItem()
        {

            for (int i = 0; i < CategoryItems.Count; i++)
                if (CategoryItems.ElementAt(i) == SelectedItem)
                {
                    CategoryItems.ElementAt(i).QuantityTemp = CategoryItems.ElementAt(i).QuantityTemp + 1;
                    CategoryItems.ElementAt(i).Quantity = CategoryItems.ElementAt(i).QuantityTemp.ToString();
                }
        }

        private void SuntractItem()
        {

            for (int i = 0; i < CategoryItems.Count; i++)
                if (CategoryItems.ElementAt(i) == SelectedItem)
                {
                    CategoryItems.ElementAt(i).QuantityTemp = CategoryItems.ElementAt(i).QuantityTemp - 1;
                    CategoryItems.ElementAt(i).Quantity = CategoryItems.ElementAt(i).QuantityTemp.ToString();
                }
        }

        private void NavigateToMyCartPage()
        {
            SaveOrderToFile();
            NavigationDispatcher.Instance.NavigationPage("MyCartPage", "", "");
        }

        private void NavigateToMainPage()
        {
            NavigationDispatcher.Instance.NavigationPage("MainPage");
        }

        public void SaveOrderToFile()
        {
            string[] str = UpdateOrderInfileModel();
            App.fileHelperProvider.SaveTextInLine(str, App.fileHelperProvider.GetAppDataPath());
        }

       public string[] UpdateOrderInfileModel()
        {
            string[] str;
            bool check = false;

            List<string> list = new List<string>();

            foreach (var item in CategoryItems)
            {
                check = false;
                if (item.QuantityTemp > 0)
                {
                    if (OrderInFileItems.Count > 0)
                        foreach (var itemOrderinFile in OrderInFileItems)
                        {
                            if (item.ID == itemOrderinFile.DetailCategoryItemID)
                            {
                                itemOrderinFile.Quantity = item.Quantity;
                                check = true;
                            }
                        }
                    if (check == false)
                    {
                        OrderInFileItems.Add(new OrderInFileModel
                        {
                            DetailCategoryItemID = item.ID,
                            Title = item.Title,
                            ImagePath = item.ImagePath,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        });
                        check = true;
                    }
                }
            }

            foreach (var item in OrderInFileItems)
            {
                if (item.Quantity != "0")
                    list.Add(item.DetailCategoryItemID + "," + item.Title + "," + item.ImagePath + "," + item.UnitPrice + "," + item.Quantity);
            }
            str = list.ToArray();
            return str;
        }

        public void IsContinueWithCurrentOrder()
        {
            if (App.fileHelperProvider.IsFileExisting(App.fileHelperProvider.GetAppDataPath()))
            {
                string tempRead = App.fileHelperProvider.ReadAllText(App.fileHelperProvider.GetAppDataPath());
                if (tempRead != "")
                {
                    CheckFile = true;
                }
            }
            if (CheckFile)
            {
                DisplayConfirmPrompt();
                CheckFile = false;
            }
            else
            {
                ResetOrderItemOnView();
            }
        }

        public void ResetOrderItemOnView()
        {
            for (int i = 0; i < CategoryItems.Count; i++)
            {
                CategoryItems.ElementAt(i).QuantityTemp = 0;
                CategoryItems.ElementAt(i).Quantity = "0";
            }
        }

        public async void DisplayConfirmPrompt()
        {
            bool result = await App.Current.MainPage.DisplayAlert("Cart", "Do you want to delete your current order in your cart?", "Yes", "No");
            OrderInFileItems = App.fileHelperProvider.ReadTextInLine(App.fileHelperProvider.GetAppDataPath());
            ResetOrderItemOnView();
            if (result)
            {
                App.fileHelperProvider.SaveText("", App.fileHelperProvider.GetAppDataPath());
                OrderInFileItems = new List<OrderInFileModel>();
            }
            if (!result)
            {
                for (int i = 0; i < CategoryItems.Count(); i++)
                {
                    for (int j = 0; j < OrderInFileItems.Count(); j++)
                    {
                        if (CategoryItems.ElementAt(i).ID.ToString() == OrderInFileItems.ElementAt(j).DetailCategoryItemID)
                        {
                            CategoryItems.ElementAt(i).Quantity = OrderInFileItems.ElementAt(j).Quantity;
                            CategoryItems.ElementAt(i).QuantityTemp = Int32.Parse(OrderInFileItems.ElementAt(j).Quantity);

                        }
                    }
                }
            }
        }
        #endregion
    }
}
