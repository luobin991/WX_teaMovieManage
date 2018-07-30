using System.Collections.Generic;
using Entity;

namespace BusinessLogic.Answer
{
    public interface I_Shop
    {


        T_ShopInfo GetShopinfo(int id);

        int SaveShopInfo(T_ShopInfo model);

        int UpdateShopInfo(T_ShopInfo model);


    }


}
