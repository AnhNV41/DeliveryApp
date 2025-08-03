using DeliveryApp.ViewModels;
using Xamarin.Forms;

namespace DeliveryApp.DisplayModels
{
    public class DisplayOrderModel : ViewModelBase
    {
        public int ID { get; set; }
        public ImageSource ImageSource { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }

        public string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == _quantity)
                    return;
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public int _quantitytemp;
        public int QuantityTemp
        {
            get { return _quantitytemp; }
            set
            {
                if (value == _quantitytemp)
                    return;
                _quantitytemp = value;
                OnPropertyChanged("QuantityTemp");
            }
        }

        public string UnitPrice { get; set; }
    }
}
