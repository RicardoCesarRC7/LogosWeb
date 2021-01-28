using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LogosWeb.Models.Repository.XMLWorker
{
    public class XMLWorker : IXMLWorker
    {
        public FileStream XmlFileStream { get; set; }
        public XmlDocument LogosXmlContent { get; set; }

        public XMLWorker () { }

        public XmlDocument Read()
        {
            XmlFileStream = new FileStream("wwwroot/logosContent/LogosWebContent.xml", FileMode.Open);

            LogosXmlContent = new XmlDocument();

            LogosXmlContent.Load(XmlFileStream);

            Close();

            return LogosXmlContent;
        }

        public XmlDocument Read(string fileName)
        {
            XmlFileStream = new FileStream($"wwwroot/logosContent/{fileName}.xml", FileMode.Open);

            LogosXmlContent = new XmlDocument();

            LogosXmlContent.Load(XmlFileStream);

            Close();

            return LogosXmlContent;
        }

        public bool Close()
        {
            if (XmlFileStream != null)
            {
                XmlFileStream.Close();
            }

            return true;
        }
    }
}
