using System.Collections.Generic;
using Entity;

namespace BusinessLogic.youdao
{
    public interface I_Youdao
    {

       int AddyoudaoQusery(string txt, string json);


        List<Entity.youdao.youdaoQusery> GetyoudaoQusery(string txt);


        List<Entity.youdao.youdaoQusery> GeTxtPage(int pageIndex, string ids);
    }
}
