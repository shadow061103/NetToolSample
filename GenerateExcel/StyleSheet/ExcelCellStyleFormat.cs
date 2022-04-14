using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelCellStyleFormat
    {
        public static CellStyleFormats GetCellStyleFormats()
        {
            var cellStyleFormats = new CellStyleFormats() { Count = (UInt32Value)1U };

            cellStyleFormats.Append(new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U });

            return cellStyleFormats;
        }
    }
}