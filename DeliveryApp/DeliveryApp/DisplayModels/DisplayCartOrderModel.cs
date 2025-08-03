using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeliveryApp.DisplayModels
{
    public class DisplayCartOrderModel
    {
        public string Weight { get; set; }
        public string Price { get; set; }
        public string Time { get; set; }
        public ObservableCollection<DisplayOrderModel> OrderItems { get; set; }
    }
}
