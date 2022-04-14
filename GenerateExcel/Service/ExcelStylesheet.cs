using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using GenerateExcel.StyleSheet;

namespace GenerateExcel.Service
{
    public class ExcelStylesheet
    {
        public static Stylesheet GetStylesheet()
        {
            var fonts = ExcelFontStyle.GetFonts();
            var fills = ExcelFillStyle.GetFills();
            var borders = ExcelBorderStyle.GetBorders();
            var cellStyleFormats = ExcelCellStyleFormat.GetCellStyleFormats();
            var cellFormats = ExcelCellFormat.GetCellFormats();
            var cellStyles = ExcelCellStyle.GetCellStyles();
            var differentialFormats = ExcelDifferentialFormat.GetDifferentialFormats();
            var tableStyles = ExcelTableStyle.GetTableStyles();

            Stylesheet stylesheet = new Stylesheet(fonts, fills, borders, cellStyleFormats,
                                cellFormats, cellStyles, differentialFormats, tableStyles);

            return stylesheet;
        }
    }
}