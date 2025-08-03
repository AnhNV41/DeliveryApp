using SQLite;

namespace DeliveryApp.Models
{
    public class CategoryItemDetailModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public double UnitPrice { get; set; }

        public int Weight { get; set; }

        public string ColorCode { get; set; } = "#FFFFFF";

        public string CategoryCode{ get; set; }

        public bool Like { get; set; } = false;
    }
}
