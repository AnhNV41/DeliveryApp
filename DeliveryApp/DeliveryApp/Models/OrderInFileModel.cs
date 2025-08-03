using System;

namespace DeliveryApp.Models
{
    public class OrderInFileModel
    {
        public string DetailCategoryItemID { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string UnitPrice { get; set; }

        public string Quantity { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
