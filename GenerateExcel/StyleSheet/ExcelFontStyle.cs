using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using GenerateExcel.StyleSheet;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelFontStyle
    {
        public static Fonts GetFonts()
        {
            var fonts = new Fonts() { Count = (UInt32Value)3U, KnownFonts = true };

            fonts.Append(SetFont(11D, 1U, "Arial", false));
            fonts.Append(SetFont(11D, 1U, "Arial", true));
            fonts.Append(SetFont(11D, 1U, "Calibri", true));

            return fonts;
        }

        private static Font SetFont(DoubleValue fontSizeSetting, UInt32Value colorTheme,
                                string fontNameValue, bool isBold)
        {
            var font = new Font();

            font.FontSize = new FontSize { Val = fontSizeSetting };
            font.Color = new Color { Theme = colorTheme };
            font.FontName = new FontName() { Val = fontNameValue };

            if (isBold)
            {
                font.Bold = new Bold();
            }

            return font;
        }
    }
}