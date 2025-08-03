using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
    public class CategoryItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ImagePath { get; set; }

        public string ColorCode { get; set; }

        public string CategoryTitle { get; set; }
    }
}
