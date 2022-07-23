using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService
{
    public static class FileServiceTest
    {
        public static void Run()
        {
            var service = new CreateFileService();
            service.CreateFile();
        }
    }
}