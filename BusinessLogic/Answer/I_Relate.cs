using System.Collections.Generic;
using Entity;

namespace BusinessLogic.Answer
{
    public interface I_Relate
    {

        int SaveRelate(T_Relate model);


        int DelRelate(int relateType, int fromID);

        List<T_Relate> GetRelates(int relateType, int fromID);


        List<T_RelateLable> GetRelateLables(string ids);

    }


}
