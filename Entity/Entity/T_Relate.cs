using System;
using Entity.Common;



namespace Entity
{

    /// <summary>
    /// 关联表
    /// </summary>
    public class T_Relate
    {
        public int id { get; set; }
        public int relateType { get; set; }
        public int fromID { get; set; }
        public int toID { get; set; }
        public int createUserID { get; set; }
        public DateTime createTime { get; set; }

    }



    /// <summary>
    /// 关联表
    /// </summary>
    public class T_RelateLable
    {
        public int id { get; set; }
        public int relateType { get; set; }
        public int fromID { get; set; }
        public int toID { get; set; }
        public string lableName { get; set; }
        public int  typeId { get; set; }

    }


}
