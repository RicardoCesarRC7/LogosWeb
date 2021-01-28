using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using LogosWeb.Models;
using LogosWeb.Models.Repository.Curso;
using LogosWeb.Models.Repository.XMLWorker;

namespace LogosWeb.Models.Repository.Professor
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IXMLWorker _xmlWorker;
        private readonly ICursoRepository _cursoRepository;
        
        public ProfessorRepository(IXMLWorker xmlWorker, ICursoRepository cursoRepository)
        {
            _xmlWorker = xmlWorker;
            _cursoRepository = cursoRepository;
        }

        public List<Models.Professor> GetProfessores()
        {
            List<Models.Professor> listaProfessores = null;

            var logosContent = _xmlWorker.Read("Professores");

            var professores = logosContent.GetElementsByTagName("Professores").Item(0);

            if (professores != null && professores.ChildNodes.Count > 0)
            {
                listaProfessores = new List<Models.Professor>();

                foreach (XmlNode professor in professores.ChildNodes)
                {
                    if (professor.Name == "Professor" && professor.ChildNodes.Count > 0)
                    {
                        Models.Professor prof = new Models.Professor();

                        foreach (XmlNode profNode in professor.ChildNodes)
                        {
                            switch (profNode.Name)
                            {
                                case "ProfessorID":
                                    prof.ProfessorID = int.Parse(profNode.InnerText);
                                    break;

                                case "Nome":
                                    prof.Nome = profNode.InnerText;
                                    break;

                                case "Descricao":
                                    prof.Descricao = profNode.InnerText;
                                    break;

                                case "Area":
                                    prof.Area = profNode.InnerText;
                                    break;

                                case "Visitante":
                                    prof.IsVisitante = profNode.InnerText == "True";
                                    break;

                                case "UrlImagem":
                                    prof.UrlImagem = profNode.InnerText;
                                    break;

                                case "Grau":
                                    prof.Grau = int.Parse(profNode.InnerText);
                                    break;

                                case "RedesSociais":

                                    if (profNode.HasChildNodes)
                                    {
                                        prof.RedesSociais = new List<RedeSocial>();

                                        int count = 0;

                                        foreach (XmlNode sociaisNode in profNode.ChildNodes)
                                        {
                                            var redeSocial = new RedeSocial { RedeSocialID = count, Nome = sociaisNode.Name, Url = sociaisNode.InnerText };

                                            prof.RedesSociais.Add(redeSocial);

                                            count++;
                                        }
                                    }

                                    break;
                            }
                        }

                        listaProfessores.Add(prof);
                    }
                }
            }

            _xmlWorker.Close();

            return listaProfessores.OrderByDescending(x => x.Grau).ToList();
        }

        public List<Models.Professor> GetProfessoresByCursoId(int cursoId)
        {
            List<Models.Professor> professores = null;

            if (cursoId > 0)
            {
                var curso = _cursoRepository.GetCursoById(cursoId);

                if (curso != null && curso.Professores != null && curso.Professores.Count > 0)
                {
                    var allProfessores = GetProfessores();

                    if (allProfessores != null && allProfessores.Count > 0)
                    {
                        professores = new List<Models.Professor>();

                        foreach (var professor in curso.Professores)
                        {
                            //if (allProfessores.Any(x => x.ProfessorID == professor))
                            //    professores.Add(allProfessores.Any(x => x.ProfessorID == professor).fi)

                            if (allProfessores.Where(x => x.ProfessorID == professor).Any())
                                professores.Add(allProfessores.Where(x => x.ProfessorID == professor).FirstOrDefault());
                        }
                    }
                }
            }

            return professores;
        }
    }
}
