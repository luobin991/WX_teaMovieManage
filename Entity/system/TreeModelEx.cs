using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.system
{
    /// <summary>
    /// 日 期：2017.11.24
    /// 描 述：树结构数据
    /// </summary>
    public class TreeModelEx<T>where T:class
    {
        /// <summary>
        /// 节点id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 父级节点ID
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 子节点列表数据
        /// </summary>
        public List<TreeModelEx<T>> ChildNodes { get; set; }
    }

}
