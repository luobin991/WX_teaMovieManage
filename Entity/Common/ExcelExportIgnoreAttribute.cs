using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Entity.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelExportIgnoreAttribute : Attribute
    {

        public ExcelExportIgnoreAttribute() { }
        public bool Ignore
        {
            get
            {
                return true;
            }
        }
    }
}
