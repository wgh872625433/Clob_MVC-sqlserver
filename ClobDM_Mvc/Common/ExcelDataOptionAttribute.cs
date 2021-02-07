using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClobDM_Mvc.Common
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true), Serializable]
    public class ExcelDataOptionAttribute:Attribute
    {
        /// <summary>
        /// 显示列下标
        /// </summary>
        public ushort ColumnIndex { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public int ColumnWidth { get; set; }
        /// <summary>
        /// 单元格数据格式
        /// </summary>
        public string Formater { get; set; }
    }
}