using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Attributes
{
    public class CSVSiteAttribute : Attribute
    {
        public CSVSiteAttribute(int site)
        {
            Site = site;
        }

        public int Site { get; private set; }
    }
}