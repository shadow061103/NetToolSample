using DocumentFormat.OpenXml.Spreadsheet;
using GenerateExcel.Attributes;
using GenerateExcel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Service
{
    public class ExcelBlockStyle
    {
        public static IEnumerable<Row> GetRows(object obj, IEnumerable<PropertyInfo> propertyInfos)
        {
            var rows = new List<Row>();
            foreach (var prop in propertyInfos)
            {
                var data = prop.GetValue(obj);

                if (prop.PropertyType.GetInterfaces().Contains(typeof(IExcelFileHeader)))
                {
                    rows.Add(prop.GenerateHeaderRow(prop.PropertyType, 3U));
                    rows.Add(prop.GenerateBodyRow(prop.PropertyType, data, 0U));
                }
                else if (prop.PropertyType.GetInterfaces()
                    .Any(x => x.Name == "IEnumerable"))
                {
                    rows.Add(prop.GenerateHeaderRow(prop.PropertyType.GetGenericArguments()[0], 3U));

                    foreach (var d in (IEnumerable<IExcelFileDetail>)data)
                        rows.Add(prop.GenerateBodyRow(prop.PropertyType.GetGenericArguments()[0], d, 0U));
                }
                else if (prop.PropertyType.GetInterfaces().Contains(typeof(IExcelFileFooter)))
                {
                    rows.Add(prop.GenerateBodyRow(prop.PropertyType, data, 4U));
                }
            }

            //空一行
            rows.Add(new Row());

            return rows;
        }
    }
}