using GenerateExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Model
{
    public class Course : IExcelFileHeader
    {
        [ExcelColumn("課程名稱")]
        [ExcelSeq(0)]
        public string CourseName { get; set; }

        [ExcelColumn("教師")]
        [ExcelSeq(1)]
        public string Teacher { get; set; }

        [ExcelColumn("上課時間")]
        [ExcelSeq(2)]
        public string Time { get; set; }
    }
}