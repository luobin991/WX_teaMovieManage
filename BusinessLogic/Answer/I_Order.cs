using System.Collections.Generic;
using Entity;

namespace BusinessLogic.Answer
{
    public interface I_Order
    {

        int SaveOrder(T_Order model);

        int SaveOrderDetail(T_orderList model);

        List<T_Order> GetOrderPage(int pageIndex, string userName);




        IEnumerable<T_Order> GetOrderPage(int pageIndex, int pageSize, string keyword);

        IEnumerable<T_orderList> GetOrderDetail(int orderId);


    }


}
