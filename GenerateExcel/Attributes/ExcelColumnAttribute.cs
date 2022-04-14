using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelColumnAttribute : Attribute
    {
        public ExcelColumnAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelSeqAttribute : Attribute
    {
        public ExcelSeqAttribute(int seq)
        {
            Seq = seq;
        }

        public int Seq { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelSheetAttribute : Attribute
    {
        public ExcelSheetAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelColumnSkipAttribute : Attribute
    {
        public ExcelColumnSkipAttribute(int skip)
        {
            Skip = skip;
        }

        public int Skip { get; private set; }
    }
}