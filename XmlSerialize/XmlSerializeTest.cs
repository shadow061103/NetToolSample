using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerialize
{
    public class XmlSerializeTest
    {
        public static void Run()
        {
            var bus = new Bus
            {
                Station = "台北車站",
                StartTime = "06:30",
                Interval = 15
            };

            var xml = XmlHelper.Serialize(bus);
            Console.WriteLine(xml);

            var obj = XmlHelper.Deserialize<Bus>(xml);
        }
    }
}