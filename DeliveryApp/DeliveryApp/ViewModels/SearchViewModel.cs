using DeliveryApp.DataBase;
using DeliveryApp.DisplayModels;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        #region Properties
        public string _inputSearch;
        public string SearchInput
        {
            get { return _inputSearch; }
            set
            {
                if (value == _inputSearch)
                    return;
                _inputSearch = value;
                OnPropertyChanged("SearchInput");
            }
        }

        public List<CategoryItemDetailModel> ListCategoryItem { get; private set; }
        public ObservableCollection<DisplayCategoryItemDetailModel> CategoryItems { get; set; }

        #endregion

        public SearchViewModel(string par1, string par2, string par3)
        {
            CategoryItems = new ObservableCollection<DisplayCategoryItemDetailModel>();
            FillterQuerry(par1, par2);
            if (par3 != "")
            {
                SearchInput = par3;
                SearchQuerry();
            }
        }

        #region Command
        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    SearchQuerry();
                });
            }
        }

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
                    NavigateToCaetegoryDetailPage();
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
                    if (action == "Clear filter")
                    {
                        NavigateToCaetegoryDetailPage();
                    }
                }
            });
        }

        public async void SearchQuerry()
        {
            DataBaseManager database = await DataBaseManager.Instance;
            ListCategoryItem = await database.GetCategoryItemDetailByName(SearchInput);
            if (ListCategoryItem != null)
                foreach (var item in ListCategoryItem)
                    CategoryItems.Add(new DisplayCategoryItemDetailModel
                    { ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly), Title = item.Title, UnitPrice= '$'+item.UnitPrice.ToString() });
        }

        public async void FillterQuerry(string par1, string par2)
        {
            DataBaseManager database = await DataBaseManager.Instance;
            if (par2 == "Liked")
            {
                ListCategoryItem = await database.GetLikedDetailCategory(par1);

            }
            else
            {
                ListCategoryItem = await database.GetCategoryItemDetailByOrder(par1, par2);
            }
            if (ListCategoryItem != null)
                foreach (var item in ListCategoryItem)
                    CategoryItems.Add(new DisplayCategoryItemDetailModel
                    { ImageSource = ImageSource.FromResource(item.ImagePath, typeof(ImageResourceExtension).GetTypeInfo().Assembly), Title = item.Title, UnitPrice = '$'+item.UnitPrice.ToString() });
        }

        private void NavigateToCaetegoryDetailPage()
        {
            NavigationDispatcher.Instance.Navigation.PopAsync();
        }
        #endregion
    }
}
