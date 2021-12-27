using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XmlSerialize;

namespace XmlSigned
{
    public class XmlSignedTest
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

            //generate key or you can use pfx file to get X509certificate
            RSA Key = RSA.Create();
            var service = new XmlSignService();
            var signXml = service.SignXmlFile(xml, Key);
            Console.WriteLine(signXml);
            var result = service.VerifyXmlFile(signXml);
            Console.WriteLine("check signedXml result:" + result);
        }
    }
}