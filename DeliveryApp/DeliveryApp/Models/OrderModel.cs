using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
    public class OrderModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int CartOrderID { get; set; }

        public string ImagePath { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
