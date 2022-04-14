using GenerateExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Model
{
    public class Student : IExcelFileDetail
    {
        [ExcelColumn("學生名稱")]
        [ExcelSeq(0)]
        public string Name { get; set; }

        [ExcelColumn("電話")]
        [ExcelSeq(0)]
        public string Phone { get; set; }
    }
}