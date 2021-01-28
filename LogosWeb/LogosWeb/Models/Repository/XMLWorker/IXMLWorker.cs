using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LogosWeb.Models.Repository.XMLWorker
{
    public interface IXMLWorker
    {
        XmlDocument Read();
        XmlDocument Read(string fileName);
        bool Close();
    }
}
