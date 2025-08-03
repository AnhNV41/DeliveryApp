using DeliveryApp.ViewModels;
using Xamarin.Forms;

namespace DeliveryApp.DisplayModels
{
    public class DisplayCategoryItemModel : ViewModelBase
    {
        public ImageSource ImageSource { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public Color ColorCode { get; set; }
    }
}
