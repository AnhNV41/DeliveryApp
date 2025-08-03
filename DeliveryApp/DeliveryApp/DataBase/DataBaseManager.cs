using DeliveryApp.Constants;
using DeliveryApp.Helper;
using DeliveryApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.DataBase
{
    public class DataBaseManager
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<DataBaseManager> Instance = new AsyncLazy<DataBaseManager>(async () =>
        {
            var instance = new DataBaseManager();
            CreateTableResult resultcategory = await Database.CreateTableAsync<CategoryItemModel>();
            CreateTableResult resultorder = await Database.CreateTableAsync<OrderModel>();
            CreateTableResult resultdetail = await Database.CreateTableAsync<CategoryItemDetailModel>();
            CreateTableResult resultstore = await Database.CreateTableAsync<StoreModel>();
            CreateTableResult resultsortorder = await Database.CreateTableAsync<CartOrderModel>();

            return instance;
        });

        public DataBaseManager()
        {
            Database = new SQLiteAsyncConnection(DataBaseConstant.DatabasePath, DataBaseConstant.Flags);
        }

        #region One record query by SQLite method
        public Task<List<CategoryItemModel>> GetCategoryAsync()
        {
            return Database.Table<CategoryItemModel>().ToListAsync();
        }

        public Task<List<OrderModel>> GetOrderAsync()
        {
            return Database.Table<OrderModel>().ToListAsync();
        }

        public Task<List<CategoryItemDetailModel>> GetDetailCategoryAsync()
        {
            return Database.Table<CategoryItemDetailModel>().ToListAsync();
        }

        public Task<List<StoreModel>> GetStoreAsync()
        {
            return Database.Table<StoreModel>().ToListAsync();
        }

        public Task<int> SaveItemAsync(CategoryItemModel item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveOrderItemAsync(OrderModel item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveDetailItemAsync(CategoryItemDetailModel item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveStoreItemAsync(StoreModel item)
        {
            if (item.ID != 0)

            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> SaveSortOrderItemAsync(CartOrderModel item)
        {
            if (item.ID != 0)

            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        #endregion

        #region Query by SQL command
        public Task<List<CartOrderModel>> GetMostRecentCartOrder()
        {
            return Database.QueryAsync<CartOrderModel>("SELECT * FROM CartOrderModel ORDER BY ID DESC");
        }

        public Task<List<OrderModel>> GetMostRecentOrderDetailCategory()
        {
            return Database.QueryAsync<OrderModel>("SELECT * FROM OrderModel WHERE CartOrderID = (SELECT ID FROM CartOrderModel ORDER BY ID DESC)");
        }

        public Task<List<CategoryItemDetailModel>> GetLikedDetailCategory(string par)
        {
            return Database.QueryAsync<CategoryItemDetailModel>("SELECT * FROM CategoryItemDetailModel WHERE Like=1 AND CategoryCode= '"+par+"'");
        }

        public Task<List<OrderModel>> GetMostRecentOrderDetailCategorybyOrderID(string orderID)
        {
            return Database.QueryAsync<OrderModel>("SELECT * FROM OrderModel WHERE CartOrderID = '" + orderID + "'");
        }

        public Task<List<OrderModel>> GetAllOrder()
        {
            return Database.QueryAsync<OrderModel>("SELECT * FROM OrderModel");
        }

        public Task<List<CategoryItemDetailModel>> GetCategoryItemDetailByName(string par)
        {
            return Database.QueryAsync<CategoryItemDetailModel>("SELECT * FROM CategoryItemDetailModel WHERE Title= '" + par + "'");
        }

        public Task<List<CategoryItemDetailModel>> GetCategoryItemDetailByOrder(string par1, string par2)
        {
            return Database.QueryAsync<CategoryItemDetailModel>("SELECT * FROM CategoryItemDetailModel WHERE CategoryCode= '" + par1 + "'" + " ORDER BY UnitPrice " + par2);
        }

        public Task<List<CategoryItemDetailModel>> GetDetailCategoryByCategoryCode(string par)
        {
            return Database.QueryAsync<CategoryItemDetailModel>("SELECT * FROM CategoryItemDetailModel WHERE CategoryCode = '" + par + "'");
        }

        public Task<List<double>> GetProductPrice(string par1)
        {
            return Database.QueryAsync<double>("SELECT UnitPrice FROM CategoryItemDetailModel WHERE CategoryCode= '" + par1 + "'");
        }
        #endregion

        #region Multi records query by SQLite methos
        public void SaveMultiItemsAsync(List<CategoryItemModel> ListCategoryItem)
        {
            Task<int> temp;
            foreach (var item in ListCategoryItem)
            {
                temp = SaveItemAsync(item);
            }
        }

        public void SaveMultiOrderItemsAsync(List<OrderModel> ListCategoryItem)
        {
            Task<int> temp;
            foreach (var item in ListCategoryItem)
            {
                temp = SaveOrderItemAsync(item);
            }
        }

        public void SaveMultiDetailItemsAsync(List<CategoryItemDetailModel> ListCategoryItem)
        {
            Task<int> temp;
            foreach (var item in ListCategoryItem)
            {
                temp = SaveDetailItemAsync(item);
            }
        }

        public void SaveMultiStoreItemsAsync(List<StoreModel> ListCategoryItem)
        {
            Task<int> temp;
            foreach (var item in ListCategoryItem)
            {
                temp = SaveStoreItemAsync(item);
            }
        }
        #endregion

        //public SQLiteConnection GetConnection()
        //{
        //    var databaseFile = Path
        //    var databaseConnection = new SQLiteConnection();
        //}
    }
}
