using LogosWeb.Models.Repository.XMLWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LogosWeb.Models.Repository.Testemunho
{
    public class TestemunhoRepository : ITestemunhoRepository
    {
        private readonly IXMLWorker _xmlWorker;

        public TestemunhoRepository(IXMLWorker xmlWorker)
        {
            _xmlWorker = xmlWorker;
        }

        public List<Models.Testemunho> GetTestemunhos()
        {
            List<Models.Testemunho> testemunhos = new List<Models.Testemunho>();

            var testemunhoContent = _xmlWorker.Read("Testemunhos");

            var testemunhosXml = testemunhoContent.GetElementsByTagName("Testemunhos").Item(0);

            if (testemunhosXml != null && testemunhosXml.ChildNodes.Count > 0)
            {
                testemunhos = new List<Models.Testemunho>();

                foreach (XmlNode testemunhoNodeXml in testemunhosXml.ChildNodes)
                {
                    if (testemunhoNodeXml.Name == "Testemunho" && testemunhoNodeXml.ChildNodes.Count > 0)
                    {
                        Models.Testemunho testemunho = new Models.Testemunho();

                        foreach (XmlNode testNode in testemunhoNodeXml.ChildNodes)
                        {
                            switch (testNode.Name)
                            {
                                case "Nome":
                                    testemunho.Nome = testNode.InnerText;
                                    break;

                                case "Descricao":
                                    testemunho.Descricao = testNode.InnerText;
                                    break;

                                case "Imagem":
                                    testemunho.Imagem = testNode.InnerText;
                                    break;
                            }
                        }

                        testemunhos.Add(testemunho);
                    }
                }
            }

            return testemunhos;
        }
    }
}
