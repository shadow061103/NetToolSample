using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel
{
    public class OpenXmlTest
    {
        public static void Run()
        {
            //https://blog.johnwu.cc/article/asp-net-core-export-to-excel.html
            //CreateEmptyExcel();
            CreateExcel();
        }

        public static void CreateExcel()
        {
            var memoryStream = new MemoryStream();
            using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());

                sheets.Append(new Sheet()
                {
                    Id = workbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet 1"
                });

                // 從 Worksheet 取得要編輯的 SheetData
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // 建立資料列物件
                var row = new Row();
                // 在資料列中插入欄位
                row.Append(
                    new Cell() { CellValue = new CellValue(1.ToString()), DataType = CellValues.Number },
                    new Cell() { CellValue = new CellValue("Steve Lin Repository"), DataType = CellValues.String },
                    new Cell() { CellValue = new CellValue("https://blog.johnwu.cc/"), DataType = CellValues.String }
                );
                // 插入資料列
                sheetData.AppendChild(row);

                row = new Row();
                // 也可以用單一欄位逐各插入
                row.Append(new Cell() { CellValue = new CellValue(2.ToString()), DataType = CellValues.Number });
                row.Append(new Cell() { CellValue = new CellValue("Steve Lin Git"), DataType = CellValues.String });
                row.Append(new Cell() { CellValue = new CellValue("https://blog.johnwu.cc/"), DataType = CellValues.String });
                sheetData.AppendChild(row);
            }

            CreateFile(memoryStream, "test.xlsx");
        }

        public static void CreateEmptyExcel()
        {
            var memoryStream = new MemoryStream();
            using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                sheets.Append(new Sheet()
                {
                    Id = workbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet 1"
                });

                //要從 MemoryStream 匯出，必須先儲存 Workbook，並關閉 SpreadsheetDocument 物件
                workbookPart.Workbook.Save();
                document.Close();
            }

            CreateFile(memoryStream, "123.xlsx");
        }

        private static void CreateFile(MemoryStream stream, string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using var outputFileStream = new FileStream(path, FileMode.Create);
            stream.WriteTo(outputFileStream);
        }
    }
}