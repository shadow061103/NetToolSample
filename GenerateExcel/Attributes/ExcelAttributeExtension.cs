using GenerateExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Attributes
{
    public static class ExcelAttributeExtension
    {
        public static string ColumnNameMapper(PropertyInfo propertyInfo)
        {
            var columnAttr = propertyInfo.GetCustomAttribute<ExcelColumnAttribute>();
            var name = string.Empty;

            if (columnAttr != null)
            {
                name = columnAttr.Name;
            }
            else
            {
                name = propertyInfo.Name;
            }

            return name;
        }

        public static int ColumnSeqMapper(PropertyInfo propertyInfo)
        {
            var columnAttr = propertyInfo.GetCustomAttribute<ExcelSeqAttribute>();
            int seq = 0;

            if (columnAttr != null)
            {
                seq = columnAttr.Seq;
            }
            else
            {
                seq = int.Parse(propertyInfo.Name);
            }

            return seq;
        }

        public static string SheetNameMapper(PropertyInfo propertyInfo)
        {
            var sheetAttr = propertyInfo.GetCustomAttribute<ExcelSheetAttribute>();
            var name = string.Empty;

            if (sheetAttr != null)
            {
                name = sheetAttr.Name;
            }
            else
            {
                name = propertyInfo.Name;
            }

            return name;
        }
    }
}