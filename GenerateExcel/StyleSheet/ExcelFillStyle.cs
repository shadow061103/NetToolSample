using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using GenerateExcel.StyleSheet;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelFillStyle
    {
        public static Fills GetFills()
        {
            var fills = new Fills() { Count = (UInt32Value)5U };

            fills.Append(GetFillNoColor());
            fills.Append(GetFillGray125());
            fills.Append(GetFillRed());
            fills.Append(GetFillBlue());
            fills.Append(GetFillYellow());

            return fills;
        }

        private static Fill GetFillNoColor()
        {
            var fill = new Fill();

            fill.PatternFill = new PatternFill() { PatternType = PatternValues.None };

            return fill;
        }

        private static Fill GetFillGray125()
        {
            var fill = new Fill();

            fill.PatternFill = new PatternFill() { PatternType = PatternValues.Gray125 };

            return fill;
        }

        private static Fill GetFillRed()
        {
            var fill = new Fill();
            var patternFill = new PatternFill() { PatternType = PatternValues.Solid };

            patternFill.ForegroundColor = new ForegroundColor() { Rgb = "FFFF0000" };
            patternFill.BackgroundColor = new BackgroundColor() { Indexed = (UInt32Value)64U };

            fill.PatternFill = patternFill;

            return fill;
        }

        private static Fill GetFillBlue()
        {
            var fill = new Fill();
            var patternFill = new PatternFill() { PatternType = PatternValues.Solid };

            patternFill.ForegroundColor = new ForegroundColor() { Rgb = "FF0070C0" };
            patternFill.BackgroundColor = new BackgroundColor() { Indexed = (UInt32Value)64U };

            fill.PatternFill = patternFill;

            return fill;
        }

        private static Fill GetFillYellow()
        {
            var fill = new Fill();
            var patternFill = new PatternFill() { PatternType = PatternValues.Solid };

            patternFill.ForegroundColor = new ForegroundColor() { Rgb = "FFD100" };
            patternFill.BackgroundColor = new BackgroundColor() { Indexed = (UInt32Value)64U };

            fill.PatternFill = patternFill;

            return fill;
        }
    }
}