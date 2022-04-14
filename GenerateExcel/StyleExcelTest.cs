using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using GenerateExcel.Attributes;
using GenerateExcel.Model;
using GenerateExcel.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel
{
    public class StyleExcelTest
    {
        public static void Run()
        {
            var data = GetFileData();
            var sheetData = GetSheetData(data);
            var stream = GetMemoryStream(sheetData);
            CreateFile(stream, "implement.xlsx");
        }

        private static ExcelFile GetFileData()
        {
            var file = new ExcelFile
            {
                ExcelSheet = new ExcelSheet
                {
                    ExcelBlock = new ExcelBlock
                    {
                        Course = new Course
                        {
                            CourseName = "財務管理",
                            Teacher = "Abby",
                            Time = "每周三10點"
                        },
                        Students = new List<Student> {
                        new Student{ Name="Steve",Phone="0910111222"},
                         new Student{ Name="Kuan",Phone="0910111222"},
                    }
                    }
                }
            };

            return file;
        }

        private static IEnumerable<ExcelSheetDataMap> GetSheetData(ExcelFile file)
        {
            var excelSheetDataMaps = new List<ExcelSheetDataMap>();
            var sheetPropertyInfos = typeof(ExcelFile).GetProperties()
                             .Where(w => w.IsDefined(typeof(ExcelSheetAttribute), false));
            //第一層Sheet
            foreach (var sheetPropertyInfo in sheetPropertyInfos)
            {
                var sheet = new ExcelSheetDataMap()
                {
                    SheetName = ExcelAttributeExtension.SheetNameMapper(sheetPropertyInfo)
                };

                var sheetData = new SheetData();
                var sheetValue = sheetPropertyInfo.GetValue(file);
                //block
                var blockPropertyInfos = sheetPropertyInfo.PropertyType.GetProperties();
                foreach (var blockPropertyInfo in blockPropertyInfos)
                {
                    //內容值
                    var blockValue = blockPropertyInfo.GetValue(sheetValue);
                    var propertyInfos = blockPropertyInfo.PropertyType.GetProperties();
                    var rows = ExcelBlockStyle.GetRows(blockValue, propertyInfos);
                    sheetData.Append(rows);
                }

                sheet.SheetData = sheetData;
                excelSheetDataMaps.Add(sheet);
            }

            return excelSheetDataMaps;
        }

        private static MemoryStream GetMemoryStream(IEnumerable<ExcelSheetDataMap> sheetDataMaps)
        {
            var memoryStream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // add styles to sheet
                WorkbookStylesPart workbookStylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                workbookStylePart.Stylesheet = ExcelStylesheet.GetStylesheet();
                workbookStylePart.Stylesheet.Save();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());

                UInt32Value id = 1;

                foreach (var sheetDataMap in sheetDataMaps)
                {
                    var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                    sheets.Append(new Sheet()
                    {
                        Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = id,
                        Name = sheetDataMap.SheetName
                    });

                    worksheetPart.Worksheet = new Worksheet(sheetDataMap.SheetData);

                    id++;
                }

                workbookPart.Workbook.Save();
                document.Close();
            }

            return memoryStream;
        }

        private static void CreateFile(MemoryStream stream, string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using var outputFileStream = new FileStream(path, FileMode.Create);
            stream.WriteTo(outputFileStream);
        }
    }
}