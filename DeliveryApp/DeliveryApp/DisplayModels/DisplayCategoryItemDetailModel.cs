using DeliveryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeliveryApp.DisplayModels
{
    public class DisplayCategoryItemDetailModel : ViewModelBase
    {
        public string ID { get; set; }
        public ImageSource ImageSource { get; set; }
        public string ImagePath { get; set; }

        public string Title{ get; set; }
     
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

        public Command PlusCommand
        {
            get
            {
                return new Command(() =>
                {
                    Quantity = (QuantityTemp = QuantityTemp + 1).ToString();
                });
            }
        }

        public Command SubtractCommand
        {
            get
            {
                return new Command(() =>
                {
                    QuantityTemp = QuantityTemp - 1;
                    QuantityTemp = (QuantityTemp <= 0) ? 0 : QuantityTemp;
                    Quantity = QuantityTemp.ToString();
                });
            }
        }

        public string UnitPrice { get; set; }

        public string DisplayUnitPrice { get; set; }

        public bool _like;
        public bool Like
        {
            get { return _like; }
            set
            {
                if (value == _like)
                    return;
                _like = value;
                OnPropertyChanged("Like");
            }
        }

        public Command LikedCommand
        {
            get
            {
                return new Command(() =>
                {
                    Like = !Like;
                });
            }
        }
        public Color ColorCode { get; set; } 

    }
}
