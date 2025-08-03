using DeliveryApp.Models;
using System.Collections.Generic;

namespace DeliveryApp.DataProvider
{
    public interface ICategoryItemDataProvider
    {
        List<CategoryItemModel> ProvideInfor();
    }

    public interface IOrderDataProvider
    {
        List<OrderModel> ProvideInfor();
        List<CartOrderModel> ProviderTempSort();
    }

    public interface ICategoryItemDetailDataProvider
    {
        List<CategoryItemDetailModel> ProvideInfor();
    }

    public interface IStoreDataProvider
    {
        List<StoreModel> ProvideInfor();
    }
}
