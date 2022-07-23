using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Attributes
{
    public class LengthAttribute : Attribute
    {
        public int Length { get; }

        public LengthAttribute(int length)
        {
            Length = length;
        }
    }
}