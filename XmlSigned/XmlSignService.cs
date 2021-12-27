using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlSigned
{
    public class XmlSignService
    {
        //PFX檔案
        public X509Certificate2 GetCert(string certPath, string pwd)
        {
            return new X509Certificate2(certPath, pwd, X509KeyStorageFlags.Exportable);
        }

        //只有PKCS7檔案
        public X509Certificate2 GetPkcs7Cert(string certPath, string cnNmae)
        {
            var content = File.ReadAllText(certPath);
            var keyByte = Convert.FromBase64String(content);
            SignedCms signedCms = new SignedCms();
            signedCms.Decode(keyByte);

            foreach (var cert in signedCms.Certificates)
            {
                if (cert.Subject.Contains(cnNmae))
                {
                    return cert;
                }
            }
            return null;
        }

        public string SignXmlFile(X509Certificate2 cert, string xmlStr)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(xmlStr);

            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = cert.GetRSAPrivateKey();

            //SignedInfo
            Reference reference = new Reference();
            reference.Uri = "";
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);
            signedXml.AddReference(reference);

            //keyinfo
            KeyInfo keyInfo = new KeyInfo();
            KeyInfoX509Data kdata = new KeyInfoX509Data(cert);
            X509IssuerSerial xserial;
            xserial.IssuerName = cert.IssuerName.Name;// cert.IssuerName.ToString();
            xserial.SerialNumber = cert.SerialNumber;
            kdata.AddIssuerSerial(xserial.IssuerName, xserial.SerialNumber);
            kdata.AddSubjectName(cert.Issuer);
            keyInfo.AddClause(kdata);
            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            //doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
            doc.DocumentElement.AppendChild(xmlDigitalSignature);

            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            //存檔
            using (XmlTextWriter xmltw = new XmlTextWriter("test.xml", new UTF8Encoding(false)))
            {
                doc.WriteTo(xmltw);
                xmltw.Close();
            }

            return doc.OuterXml;
        }

        public bool Verify(X509Certificate2 cert, string xmlStr)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlStr);

            SignedXml signedXml = new SignedXml(xmlDocument);
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");
            signedXml.LoadXml((XmlElement)nodeList[0]);

            return signedXml.CheckSignature(cert, true);
        }

        //微軟官方版本
        public string SignXmlFile(string xmlStr, RSA Key)
        {
            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Format the document to ignore white spaces.
            doc.PreserveWhitespace = false;

            // Load the passed XML file using it's name.
            doc.LoadXml(xmlStr);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = Key;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)Key));
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            // Save the signed XML document to a file specified
            // using the passed string.
            XmlTextWriter xmltw = new XmlTextWriter("test.xml", new UTF8Encoding(false));
            doc.WriteTo(xmltw);
            xmltw.Close();

            return doc.OuterXml;
        }

        // Verify the signature of an XML file and return the result.
        public bool VerifyXmlFile(string xmlStr)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Format using white spaces.
            xmlDocument.PreserveWhitespace = true;

            // Load the passed XML file into the document.
            xmlDocument.LoadXml(xmlStr);

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDocument);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

            // Load the signature node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result.
            return signedXml.CheckSignature();
        }
    }
}