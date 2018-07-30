using System;
using System.ComponentModel;
using System.Reflection;


namespace  Common
{

    /// <summary>
    /// 日 期：2017.10.07
    /// 描 述：获取实体类Attribute自定义属性
    /// </summary>
    public class EnumAttribute
    {
        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(Enum val)
        {
            Type enumType = val.GetType();
            string name = Enum.GetName(enumType, val);
            if (name!=null)
            {
                FieldInfo fielInfo = enumType.GetField(name);
                if (fielInfo!=null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fielInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr!=null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }


    }




}
