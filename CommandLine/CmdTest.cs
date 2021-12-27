using System;
using System.Collections.Generic;

namespace CommandLine
{
    public class CmdTest
    {
        public static void Run()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var cmd = "ipconfig";
            var result = CommandHelper.ExecuteCommand(path, new List<string> { cmd });
            Console.WriteLine(result);
        }
    }
}