using DeliveryApp.Models;
using System;
using System.Collections.Generic;

namespace DeliveryApp.DataProvider
{
    public class DataProviderInitialize : ICategoryItemDataProvider
    {
        public List<CategoryItemModel> tempCategory;

        public DataProviderInitialize()
        {
            tempCategory = new List<CategoryItemModel>
            {
                new CategoryItemModel()
                   {
                       ImagePath = "DeliveryApp.Resource.fruits.png",
                       CategoryTitle = "Fruits",
                       ColorCode="#EBF5FB"
                   },
                new CategoryItemModel()
                   {
                       ImagePath = "DeliveryApp.Resource.vegetables.png",
                       CategoryTitle = "Vegetables",
                       ColorCode="#EBF5FB"
                   },
                new CategoryItemModel()
                   {
                       ImagePath = "DeliveryApp.Resource.shoes.png",
                       CategoryTitle = "Shoes",
                       ColorCode="#EBF5FB"
                   },
                new CategoryItemModel()
                   {
                       ImagePath = "DeliveryApp.Resource.sport.png",
                       CategoryTitle = "Sport",
                       ColorCode="#EBF5FB"
                   },
                new CategoryItemModel()
                   {
                       ImagePath = "DeliveryApp.Resource.food.png",
                       CategoryTitle = "Food",
                       ColorCode="#EBF5FB"
                   },
                  new CategoryItemModel()
                   {
                       ImagePath = "DeliveryApp.Resource.drink.png",
                       CategoryTitle = "Drink",
                       ColorCode="#EBF5FB"
                   },
             };
        }

        public List<CategoryItemModel> ProvideInfor()
        {
            return tempCategory;
        }
    }

    public class ModelDataProviderInitialize : IOrderDataProvider
    {
        public List<OrderModel> tempOrder;

        public List<CartOrderModel> tempSort;

        public ModelDataProviderInitialize()
        {
            tempOrder = new List<OrderModel>
            {
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now,
                    
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Quantity = 1,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Quantity=2,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Quantity=3,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
                new OrderModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Quantity=4,
                    CartOrderID=1,
                    OrderTime=DateTime.Now
                    },
             };

            tempSort = new List<CartOrderModel>
            {
                new CartOrderModel()
                {
                    OrderTime=DateTime.Now,
                }
            };
        }

        public List<OrderModel> ProvideInfor()
        {
            return tempOrder;
        }
        public List<CartOrderModel> ProviderTempSort()
        {
            return tempSort;
        }

    }

    public class DetailModelDataProviderInitialize : ICategoryItemDetailDataProvider
    {
        public List<CategoryItemDetailModel> tempCategory;

        public DetailModelDataProviderInitialize()
        {
            tempCategory = new List<CategoryItemDetailModel>
            {
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Title="Red Grape",
                    UnitPrice=0.9,
                    CategoryCode="Fruits",
                    ColorCode="#EBF5FB",
                    Like=true
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fruits2.png",
                    Title="Purple Grape",
                    UnitPrice=1.9,
                    CategoryCode="Fruits",
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits",
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Black Grape",
                    UnitPrice=3.9,
                    CategoryCode="Fruits",
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.apple.png",
                    Title="Apple",
                    UnitPrice=4.9,
                    CategoryCode="Fruits",
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Orange Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.drink3.png",
                    Title="Strawberry Coctail",
                    UnitPrice=2.9,
                    CategoryCode="Drink"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.drink4.png",
                    Title="Blue Coctail",
                    UnitPrice=3.9,
                    CategoryCode="Drink"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.drink5.png",
                    Title="Orange Coctail",
                    UnitPrice=4.9,
                    CategoryCode="Drink"
                 },
                 new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink6.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink7.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.drink8.png",
                    Title="Coke",
                    UnitPrice=2.9,
                    CategoryCode="Drink"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.shoes1.png",
                    Title="Leather shoes",
                    UnitPrice=3.9,
                    CategoryCode="Shoes",
                    Like=true
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.shoes2.png",
                    Title="Sport shoes",
                    UnitPrice=4.9,
                    CategoryCode="Shoes"
                 },
                 new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.shoes3.png",
                    Title="Running shoes",
                    UnitPrice=4.9,
                    CategoryCode="Shoes"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vegetables1.png",
                    Title="Cabbage",
                    UnitPrice=0.9,
                    CategoryCode="Vegetables",
                    Like=true
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vagetables2.png",
                    Title="Tomato",
                    UnitPrice=1.9,
                    CategoryCode="Vegetables",
                    Like=true
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.vegetables3.png",
                    Title="Carrot",
                    UnitPrice=2.9,
                    CategoryCode="Vegetables"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.vegetables4.png",
                    Title="Yellow Corn",
                    UnitPrice=3.9,
                    CategoryCode="Vegetables"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.vegetables5.png",
                    Title="Onion",
                    UnitPrice=4.9,
                    CategoryCode="Vegetables"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                   CategoryCode="Drink"

                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                     CategoryCode="Drink"

                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.apple.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.apple1.png",
                    Title="USA Apple",
                    UnitPrice=3.9,
                    CategoryCode="Fruits"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.apple2.png",
                    Title="Aus Apple",
                    UnitPrice=4.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.fruits2.png",
                    Title="Black Grape",
                    UnitPrice=3.9,
                    CategoryCode="Fruits"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Red Grape",
                    UnitPrice=4.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Fruits"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Fruits"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.fruits2.png",
                    Title="Black Grape",
                    UnitPrice=3.9,
                    CategoryCode="Fruits"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Red Grape",
                    UnitPrice=4.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Fruits"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Fruits"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.fruits2.png",
                    Title="Black Grape",
                    UnitPrice=3.9,
                    CategoryCode="Fruits"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Red Grape",
                    UnitPrice=4.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.fruits2.png",
                    Title="Black Grape",
                    UnitPrice=3.9,
                    CategoryCode="Fruits"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Red Grape",
                    UnitPrice=4.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink1.png",
                    Title="Mangle Coctail",
                    UnitPrice=0.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                   {
                    ImagePath = "DeliveryApp.Resource.drink2.png",
                    Title="Lemon Coctail",
                    UnitPrice=1.9,
                    CategoryCode="Drink"
                    },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits1.png",
                    Title="Red Grape",
                    UnitPrice=2.9,
                    CategoryCode="Fruits"
                 },
                new CategoryItemDetailModel()
                 {
                    ImagePath = "DeliveryApp.Resource.fruits2.png",
                    Title="Black Grape",
                    UnitPrice=3.9,
                    CategoryCode = "Fruits"
                  },
                new CategoryItemDetailModel()
                {
                    ImagePath = "DeliveryApp.Resource.fruits3.png",
                    Title="Red Grape",
                    UnitPrice=4.9,
                    CategoryCode="Fruits"
                 },
             };
        }

        public List<CategoryItemDetailModel> ProvideInfor()
        {
            return tempCategory;
        }
    }

    public class StoreModelDataProviderInitialize : IStoreDataProvider
    {
        public List<StoreModel> tempCategory;

        public StoreModelDataProviderInitialize()
        {
            tempCategory = new List<StoreModel>
            {
                new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.costco.png",
                    StoreName="Cosco",
                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.cba.png",
                    StoreName="CBA",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.pngegg.png",
                    StoreName="BIM",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.pngwing.com.png",
                    StoreName="PENNY MARKET",
                    },
                     new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.carlsberg.png",
                    StoreName="Carlsberg",

                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.bunge.jpg",
                    StoreName="Bunge",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.circlek.png",
                    StoreName="Circle K",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.cocacola.png",
                    StoreName="Cocacola",
                    },
                     new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.danishcrown.png",
                    StoreName="Danish Crown",

                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.danone.png",
                    StoreName="Danone",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.dean.png",
                    StoreName="Dean",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.diageo.png",
                    StoreName="Diageo",
                    },
                     new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.fontera.png",
                    StoreName="Fontera",

                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.hormel.jpg",
                    StoreName="Hormel",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.ingredion.png",
                    StoreName="Ingredion",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.kfc.png",
                    StoreName="KFC",
                    },
                     new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.meiji.png",
                    StoreName="Meiji",

                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.nestle.png",
                    StoreName="Nestle",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.nhfoods.png",
                    StoreName="NH Foods",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.osi.png",
                    StoreName="OSI",
                    },
                     new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.pepsico.jpg",
                    StoreName="Pepsico",

                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.pernod recard.png",
                    StoreName="Pernod Recard",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.redbull.jpg",
                    StoreName="Red Bull",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.sapporo.jpeg",
                    StoreName="Sapporo",
                    },
                     new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.simplot.png",
                    StoreName="Simplot",

                    },
                  new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.thaibev.jpg",
                    StoreName="Thaibev",

                    },
                   new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.tsingtao.png",
                    StoreName="Tsingtao",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.unilever.jpg",
                    StoreName="Unilever",
                    },
                       new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.vion.jpg",
                    StoreName="BIM",

                    },
                    new StoreModel()
                   {
                    ImagePath = "DeliveryApp.Resource.arla.png",
                    StoreName="Arla",
                    },
             };
        }

        public List<StoreModel> ProvideInfor()
        {
            return tempCategory;
        }
    }

}
