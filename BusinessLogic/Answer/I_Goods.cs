using System.Collections.Generic;
using Entity;

namespace BusinessLogic.Answer
{
    public interface I_Goods
    {


        T_Goods GetGoodsData(int id);

        int SaveGoods(T_Goods model);

        int UpdateGoods(T_Goods model);

        int DelGoodsByparentID(int pid);

        int UpdateGoodsStatus(int id, int status);

        List<T_Goods> GetGoodsPage(T_Goods model);

        int DelGoodsByID(int id);


        List<T_Goods> GetGoodsBypid(int id);
    }


}
