using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelCellStyle
    {
        public static CellStyles GetCellStyles()
        {
            var cellStyles = new CellStyles() { Count = (UInt32Value)1U };

            cellStyles.Append(new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U });

            return cellStyles;
        }
    }
}