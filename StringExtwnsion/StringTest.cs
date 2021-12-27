using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public class StringTest
    {
        public static void Run()
        {
            var text = "abc123";
            Console.WriteLine(text.ToSBC());
        }
    }
}