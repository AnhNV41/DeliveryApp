using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
    public class StoreModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string StoreName { get; set; }

        public string ImagePath { get; set; }
    }
}
