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
            XmlSignedTest.Run();
            Console.ReadKey();
        }
    }
}