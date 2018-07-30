using System.Collections.Generic;
using Entity;

namespace BusinessLogic.Answer
{
    public interface I_Lable
    {

         int SaveLableType(T_Lable model);

        int SaveLableDetail(T_LableDetail model);

        int UpdateLableType(T_Lable model);

        int UpdateLableDetail(T_LableDetail model);


        int DelLable(int id);

        int DelLableDetail(int id);

        int DelLableDetailByParentID(int pid);

        T_Lable GetLable(int id, int typeid);

        List<T_Lable> GetLables();

        List<T_Lable> GetLables(int typeid);

        List<T_Lable> GetLable_Datail(T_Lable model);

        T_LableDetail GetLableDetail(int id);

        List<T_LableDetail> GetlableDetailPage(T_LableDetail model);


        /// <summary>
        /// 获取产品标签，包括标签明细
        /// </summary>
        /// <param name="relateType"></param>
        /// <param name="fromID"></param>
        /// <returns></returns>
        List<T_Lable> GetLables(int relateType, int fromID);

    }


}
