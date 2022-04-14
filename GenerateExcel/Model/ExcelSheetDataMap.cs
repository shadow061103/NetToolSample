using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Model
{
    public class ExcelSheetDataMap
    {
        public SheetData SheetData { get; set; }

        public string SheetName { get; set; }
    }
}