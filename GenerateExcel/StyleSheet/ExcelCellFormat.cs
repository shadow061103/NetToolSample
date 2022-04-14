using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelCellFormat
    {
        public static CellFormats GetCellFormats()
        {
            var cellFormats = new CellFormats() { Count = (UInt32Value)5U };

            cellFormats.Append(GetNoBackgroundAndNoBorder());
            cellFormats.Append(GetRedBackgroundAndNoBorder());
            cellFormats.Append(GetBlueBackgroundAndNoBorder());
            cellFormats.Append(GetYellowBackgroundAndNoBorderWithBold());
            cellFormats.Append(GetNoBackgroundAndWithTopBorder());

            return cellFormats;
        }

        /// <summary>
        /// style index : 0U no-background no border
        /// </summary>
        /// <returns></returns>
        private static CellFormat GetNoBackgroundAndNoBorder()
        {
            var alignment = GetBasicAlignment();

            return new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, Alignment = alignment, ApplyFill = true };
        }

        /// <summary>
        /// style index : 1U Red no border
        /// </summary>
        /// <returns></returns>
        private static CellFormat GetRedBackgroundAndNoBorder()
        {
            var alignment = GetBasicAlignment();

            return new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, Alignment = alignment, ApplyFill = true };
        }

        /// <summary>
        /// style index : 2U blue no border
        /// </summary>
        /// <returns></returns>
        private static CellFormat GetBlueBackgroundAndNoBorder()
        {
            var alignment = GetBasicAlignment();

            return new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)3U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, Alignment = alignment, ApplyFill = true };
        }

        /// <summary>
        /// style index : 3U yellow no border, with bold
        /// </summary>
        /// <returns></returns>
        private static CellFormat GetYellowBackgroundAndNoBorderWithBold()
        {
            var alignment = GetBasicAlignment();

            return new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, Alignment = alignment, ApplyFill = true };
        }

        /// <summary>
        /// style index : 4U no-background with top border
        /// </summary>
        /// <returns></returns>
        private static CellFormat GetNoBackgroundAndWithTopBorder()
        {
            var alignment = GetBasicAlignment();

            return new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)2U, FormatId = (UInt32Value)0U, Alignment = alignment, ApplyFill = true };
        }

        private static Alignment GetBasicAlignment()
        {
            return new Alignment() { Horizontal = new EnumValue<HorizontalAlignmentValues> { Value = HorizontalAlignmentValues.Center }, Vertical = new EnumValue<VerticalAlignmentValues> { Value = VerticalAlignmentValues.Center }, TextRotation = 0U };
        }
    }
}