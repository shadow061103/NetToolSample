using GenerateExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Model
{
    public class ExcelFile
    {
        [ExcelSheet("課程列表")]
        public ExcelSheet ExcelSheet { get; set; }
    }

    public class ExcelSheet
    {
        public ExcelBlock ExcelBlock { get; set; }
    }

    public class ExcelBlock : IExcelFileBlock
    {
        public Course Course { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }

    public interface IExcelFileBlock
    {
    }

    public interface IExcelFileDetail
    {
    }

    public interface IExcelFileHeader
    {
    }

    public interface IExcelFileFooter
    { }
}