using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using GenerateExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Service
{
    public static class ExcelRowGenerate
    {
        public static Row GenerateHeaderRow(this PropertyInfo propertyInfo, Type type, UInt32Value styleIndex)
        {
            //取得設定Attribute的header name
            var row = new Row();
            var skipColumn = propertyInfo.GetCustomAttribute<ExcelColumnSkipAttribute>();
            var skip = 0;

            if (skipColumn is not null)
            {
                skip = skipColumn.Skip;
            }

            var headerProperties = type.GetProperties()
                           .Where(w => w.IsDefined(typeof(ExcelSeqAttribute), false))
                           .OrderBy(o => ((ExcelSeqAttribute)o.GetCustomAttributes(typeof(ExcelSeqAttribute), false)[0]).Seq);

            for (var i = 0; i < skip; i++)
            {
                row.Append(new Cell { CellValue = new CellValue(""), DataType = CellValues.String });
            }

            foreach (var header in headerProperties)
            {
                row.Append(new Cell { CellValue = new CellValue(ExcelAttributeExtension.ColumnNameMapper(header)), DataType = CellValues.String, StyleIndex = styleIndex });
            }

            return row;
        }

        public static Row GenerateBodyRow(this PropertyInfo propertyInfo, Type type, object data, UInt32Value styleIndex)
        {
            var row = new Row();
            var skipColumn = propertyInfo.GetCustomAttribute<ExcelColumnSkipAttribute>();
            var skip = 0;

            if (skipColumn is not null)
            {
                skip = skipColumn.Skip;
            }

            var properties = type.GetProperties()
                          .Where(w => w.IsDefined(typeof(ExcelSeqAttribute), false))
                          .OrderBy(o => ((ExcelSeqAttribute)o.GetCustomAttributes(typeof(ExcelSeqAttribute), false)[0]).Seq);

            for (var i = 0; i < skip; i++)
            {
                row.Append(new Cell { CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = styleIndex });
            }

            foreach (var header in properties)
            {
                row.Append(new Cell { CellValue = new CellValue(header.GetValue(data).ToString()), DataType = CellValues.String, StyleIndex = styleIndex });
            }

            return row;
        }
    }
}