using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.StyleSheet
{
    public static class ExcelBorderStyle
    {
        public static Borders GetBorders()
        {
            var borders = new Borders() { Count = (UInt32Value)6U };

            borders.Append(GetNoneBorder());
            borders.Append(GetAllBorder());
            borders.Append(GetTopBorder());
            borders.Append(GetBottomBorder());
            borders.Append(GetLeftBorder());
            borders.Append(GetRightBorder());

            return borders;
        }

        private static Border GetNoneBorder()
        {
            return new Border();
        }

        private static Border GetAllBorder()
        {
            var border = new Border();

            border.TopBorder = new TopBorder { Style = BorderStyleValues.Thin };
            border.BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin };
            border.LeftBorder = new LeftBorder { Style = BorderStyleValues.Thin };
            border.RightBorder = new RightBorder { Style = BorderStyleValues.Thin };

            return border;
        }

        private static Border GetTopBorder()
        {
            var border = new Border();

            border.TopBorder = new TopBorder { Style = BorderStyleValues.Thin };

            return border;
        }

        private static Border GetBottomBorder()
        {
            var border = new Border();

            border.BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin };

            return border;
        }

        private static Border GetLeftBorder()
        {
            var border = new Border();

            border.LeftBorder = new LeftBorder { Style = BorderStyleValues.Thin };

            return border;
        }

        private static Border GetRightBorder()
        {
            var border = new Border();

            border.RightBorder = new RightBorder { Style = BorderStyleValues.Thin };

            return border;
        }
    }
}