using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
    public class CartOrderModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public double TotalPrice { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
