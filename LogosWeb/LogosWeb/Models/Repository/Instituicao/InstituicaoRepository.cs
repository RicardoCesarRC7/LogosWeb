using LogosWeb.Models.Repository.XMLWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LogosWeb.Models.Repository.Instituicao
{
    public class InstituicaoRepository : IInstituicaoRepository
    {

        private readonly IXMLWorker _xmlWorker;

        public InstituicaoRepository(IXMLWorker xmlWorker)
        {
            _xmlWorker = xmlWorker;
        }

        public Models.Instituicao GetInstituicaoInfo()
        {
            Models.Instituicao logosInfo = null;

            var logosContent = _xmlWorker.Read();

            var instituicaoXml = logosContent.GetElementsByTagName("Instituicao").Item(0);

            if (instituicaoXml != null && instituicaoXml.ChildNodes.Count > 0)
            {
                logosInfo = new Models.Instituicao();

                foreach (XmlNode instituicaoNode in instituicaoXml.ChildNodes)
                {
                    switch (instituicaoNode.Name)
                    {
                        case "Sobre":

                            if (instituicaoNode.HasChildNodes)
                            {
                                foreach (XmlNode sobreNode in instituicaoNode.ChildNodes)
                                {
                                    switch (sobreNode.Name)
                                    {
                                        case "Nome":
                                            logosInfo.Nome = sobreNode.InnerText;
                                            break;

                                        case "Missao":
                                            logosInfo.Missao = sobreNode.InnerText;
                                            break;

                                        case "Visao":
                                            logosInfo.Visao = sobreNode.InnerText;
                                            break;

                                        case "Valores":

                                            if (sobreNode.HasChildNodes)
                                            {
                                                logosInfo.Valores = new List<Valor>();

                                                foreach (XmlNode valorNode in sobreNode.ChildNodes)
                                                {
                                                    var valor = new Valor();

                                                    foreach (XmlNode valorContentNode in valorNode.ChildNodes)
                                                    {
                                                        switch (valorContentNode.Name)
                                                        {
                                                            case "Nome":
                                                                valor.Nome = valorContentNode.InnerText;
                                                                break;

                                                            case "Icone":
                                                                valor.Icone = valorContentNode.InnerText;
                                                                break;
                                                        }
                                                    }

                                                    logosInfo.Valores.Add(valor);
                                                }
                                            }
                                            
                                            break;

                                        case "Historia":
                                            logosInfo.Historia = sobreNode.InnerText;
                                            break;

                                        case "DeclaracaoDoutrinaria":
                                            logosInfo.DeclaracaoDoutrinaria = sobreNode.InnerText;
                                            break;

                                        case "Endereco":
                                            logosInfo.Endereco = sobreNode.InnerText;
                                            break;

                                        case "RedesSociais":

                                            if (sobreNode.HasChildNodes)
                                            {
                                                logosInfo.RedesSociais = new List<RedeSocial>();

                                                int count = 0;

                                                foreach (XmlNode sociaisNode in sobreNode.ChildNodes)
                                                {
                                                    var redeSocial = new RedeSocial { RedeSocialID = count, Nome = sociaisNode.Name, Url = sociaisNode.InnerText };

                                                    logosInfo.RedesSociais.Add(redeSocial);

                                                    count++;
                                                }
                                            }

                                            break;
                                    }
                                }
                            }

                            break;

                        case "Contato":

                            if (instituicaoNode.HasChildNodes)
                            {
                                foreach (XmlNode contatoNode in instituicaoNode.ChildNodes)
                                {
                                    switch (contatoNode.Name)
                                    {
                                        case "Telefone":
                                            logosInfo.Telefone = contatoNode.InnerText;
                                            break;

                                        case "Whatsapp":
                                            logosInfo.Whatsapp = contatoNode.InnerText;
                                            break;

                                        case "Email":
                                            logosInfo.Email = contatoNode.InnerText;
                                            break;
                                    }
                                }
                            }

                            break;
                    }
                }
            }

            _xmlWorker.Close();

            return logosInfo;
        }

        public Models.Instituicao GetContatoInfo()
        {
            Models.Instituicao logosInfo = null;

            var contatoContent = _xmlWorker.Read("Contato");

            var contatoXml = contatoContent.GetElementsByTagName("Contato").Item(0);

            if (contatoXml != null && contatoXml.ChildNodes.Count > 0)
            {
                logosInfo = new Models.Instituicao();

                foreach (XmlNode contatoNode in contatoXml.ChildNodes)
                {
                    switch (contatoNode.Name)
                    {
                        case "Telefone":
                            logosInfo.Telefone = contatoNode.InnerText;
                            break;

                        case "Whatsapp":
                            logosInfo.Whatsapp = contatoNode.InnerText;
                            break;

                        case "Email":
                            logosInfo.Email = contatoNode.InnerText;
                            break;
                    }
                }
            }

            var redesSociaisXml = contatoContent.GetElementsByTagName("RedesSociais").Item(0);

            if (redesSociaisXml.HasChildNodes)
            {
                logosInfo.RedesSociais = new List<RedeSocial>();

                int count = 0;

                foreach (XmlNode sociaisNode in redesSociaisXml.ChildNodes)
                {
                    var redeSocial = new RedeSocial { RedeSocialID = count, Nome = sociaisNode.Name, Url = sociaisNode.InnerText };

                    logosInfo.RedesSociais.Add(redeSocial);

                    count++;
                }
            }

            return logosInfo;
        }

        public Models.Instituicao GetValoresInfo()
        {
            Models.Instituicao logosInfo = null;

            var valoresContent = _xmlWorker.Read("Valores");

            var valoresXml = valoresContent.GetElementsByTagName("Valores").Item(0);

            if (valoresXml != null && valoresXml.ChildNodes.Count > 0)
            {
                logosInfo = new Models.Instituicao();

                logosInfo.Valores = new List<Valor>();

                foreach (XmlNode valorNode in valoresXml.ChildNodes)
                {
                    var valor = new Valor();

                    foreach (XmlNode valorContentNode in valorNode.ChildNodes)
                    {
                        switch (valorContentNode.Name)
                        {
                            case "Nome":
                                valor.Nome = valorContentNode.InnerText;
                                break;

                            case "Icone":
                                valor.Icone = valorContentNode.InnerText;
                                break;

                            case "Descricao":
                                valor.Descricao = valorContentNode.InnerText;
                                break;
                        }
                    }

                    logosInfo.Valores.Add(valor);
                }
            }

            return logosInfo;
        }
    }
}
