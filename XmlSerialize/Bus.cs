using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerialize
{
    public class Bus
    {
        /// <summary>
        /// 站名
        /// </summary>
        public string Station { get; set; }

        /// <summary>
        /// 發車時間
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 班次間距
        /// </summary>
        public int Interval { get; set; }
    }
}