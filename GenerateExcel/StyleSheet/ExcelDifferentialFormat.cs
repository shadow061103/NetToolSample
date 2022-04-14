using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelDifferentialFormat
    {
        public static DifferentialFormats GetDifferentialFormats()
        {
            var differentialFormats = new DifferentialFormats() { Count = (UInt32Value)0U };

            return differentialFormats;
        }
    }
}