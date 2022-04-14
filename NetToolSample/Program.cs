using CommandLine;
using GenerateExcel;
using StringExtension;
using System;
using XmlSerialize;
using XmlSigned;

namespace NetToolSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //XmlSerializeTest.Run();
            //XmlSignedTest.Run();
            //CmdTest.Run();
            //StringTest.Run();
            //OpenXmlTest.Run();
            StyleExcelTest.Run();
            Console.ReadKey();
        }
    }
}