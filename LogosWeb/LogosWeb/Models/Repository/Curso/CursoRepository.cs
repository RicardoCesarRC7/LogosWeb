using LogosWeb.Models.Enum;
using LogosWeb.Models.Repository.XMLWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LogosWeb.Models.Repository.Curso
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IXMLWorker _xmlWorker;

        public CursoRepository(IXMLWorker xmlWorker)
        {
            _xmlWorker = xmlWorker;
        }

        public List<Models.Curso> GetCursos()
        {
            List<Models.Curso> listaCursos = null;

            var logosContent = _xmlWorker.Read("Cursos");

            var cursosXml = logosContent.GetElementsByTagName("Cursos").Item(0);

            if (cursosXml != null && cursosXml.ChildNodes.Count > 0)
            {
                listaCursos = new List<Models.Curso>();

                foreach (XmlNode cursoNodeXml in cursosXml.ChildNodes)
                {
                    if (cursoNodeXml.Name == "Curso" && cursoNodeXml.ChildNodes.Count > 0)
                    {
                        Models.Curso curso = new Models.Curso();

                        foreach (XmlNode cursoNode in cursoNodeXml.ChildNodes)
                        {
                            switch (cursoNode.Name)
                            {
                                case "CursoID":
                                    curso.CursoID = int.Parse(cursoNode.InnerText);
                                    break;

                                case "Nome":
                                    curso.Nome = cursoNode.InnerText;
                                    break;

                                case "Descricao":
                                    curso.Descricao = cursoNode.InnerText;
                                    break;

                                case "HorarioAulas":
                                    curso.Horario = cursoNode.InnerText;
                                    break;

                                case "Duracao":
                                    curso.Duracao = cursoNode.InnerText;
                                    break;

                                case "Formato":

                                    var formatosArr = cursoNode.InnerText.Split(',', StringSplitOptions.RemoveEmptyEntries);

                                    if (formatosArr.Count() > 0)
                                    {
                                        curso.Formato = new List<EInteresseFormato>();

                                        foreach (var formato in formatosArr)
                                        {
                                            curso.Formato.Add((EInteresseFormato)int.Parse(formato));

                                        }
                                    }

                                    break;

                                case "Publicoalvo":
                                    curso.Publico = cursoNode.InnerText;
                                    break;

                                case "Categoria":
                                    curso.Categoria = cursoNode.InnerText;
                                    break;

                                case "Grau":
                                    curso.Grau = cursoNode.InnerText;
                                    break;

                                case "Professores":

                                    var stringprofs = !string.IsNullOrEmpty(cursoNode.InnerText) ? cursoNode.InnerText.Split(',', StringSplitOptions.RemoveEmptyEntries) : new string[0];

                                    if (stringprofs.Count() > 0)
                                    {
                                        curso.Professores = new List<int>();

                                        foreach (string strProf in stringprofs)
                                        {
                                            curso.Professores.Add(int.Parse(strProf.Replace(" ", "")));
                                        }
                                    }

                                    break;

                                case "Grade":

                                    if (cursoNode != null && cursoNode.HasChildNodes)
                                    {
                                        curso.Grade = new Grade();

                                        curso.Grade.GradeID = 1;

                                        int counter = 1;

                                        foreach (XmlNode gradeNode in cursoNode.ChildNodes)
                                        {
                                            switch (gradeNode.Name)
                                            {
                                                case "Show":
                                                    curso.Grade.Show = gradeNode.InnerText == "True";
                                                    break;

                                                case "Semestres":

                                                    if (gradeNode != null && gradeNode.HasChildNodes)
                                                    {
                                                        curso.Grade.Semestres = new List<Semestre>();

                                                        foreach (XmlNode semestresNode in gradeNode.ChildNodes)
                                                        {
                                                            Semestre semestre = new Semestre();

                                                            semestre.Disciplinas = new List<Disciplina>();

                                                            foreach (XmlNode semestreNode in semestresNode.ChildNodes)
                                                            {
                                                                if (semestreNode.Name == "SemestreID")
                                                                {
                                                                    semestre.SemestreID = int.Parse(semestreNode.InnerText);
                                                                }
                                                                else
                                                                {
                                                                    foreach (XmlNode disciplinaNode in semestreNode.ChildNodes)
                                                                    {
                                                                        Disciplina disciplina = new Disciplina();

                                                                        disciplina.DisciplinaID = counter;
                                                                        disciplina.Nome = disciplinaNode.InnerText;

                                                                        semestre.Disciplinas.Add(disciplina);

                                                                        counter++;
                                                                    }
                                                                }
                                                            }

                                                            curso.Grade.Semestres.Add(semestre);
                                                        }
                                                    }

                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case "Financeiro":

                                    if (cursoNode.HasChildNodes)
                                    {
                                        curso.Financeiro = new List<Financeiro>();

                                        foreach (XmlNode financeiroNode in cursoNode.ChildNodes)
                                        {
                                            var financa = new Financeiro();

                                            foreach (XmlNode financaNode in financeiroNode.ChildNodes)
                                            {
                                                switch (financaNode.Name)
                                                {
                                                    case "ValorMensalidade":
                                                        financa.ValorMensalidade = decimal.Parse(financaNode.InnerText);
                                                        break;

                                                    case "Informacao":
                                                        financa.Descricao = financaNode.InnerText;
                                                        break;
                                                }
                                            }

                                            curso.Financeiro.Add(financa);
                                        }
                                    }

                                    break;

                                case "UrlImagem":
                                    curso.UrlImagemPrincipal = cursoNode.InnerText;
                                    break;

                                case "Imagens":

                                    if (cursoNode.HasChildNodes)
                                    {
                                        curso.Imagens = new List<string>();

                                        foreach (XmlNode imagensNode in cursoNode.ChildNodes)
                                        {
                                            string imagem = imagensNode.InnerText;

                                            curso.Imagens.Add(imagem);
                                        }
                                    }

                                    break;
                            }
                        }

                        listaCursos.Add(curso);
                    }
                }
            }

            _xmlWorker.Close();

            return listaCursos;
        }

        public Models.Curso GetCursoById(int cursoId)
        {
            Models.Curso curso = null;

            if (cursoId > 0)
            {
                var cursos = GetCursos();

                if (cursos != null && cursos.Count > 0)
                {
                    curso = cursos.Where(x => x.CursoID == cursoId).FirstOrDefault();
                }
            }

            return curso;
        }

        public List<Models.Curso> GetCursosByGrau(string grau)
        {
            List<Models.Curso> cursos = null;

            if (!string.IsNullOrEmpty(grau))
            {
                cursos = new List<Models.Curso>();

                var allCursos = GetCursos();

                if (allCursos != null && allCursos.Count > 0)
                {
                    cursos = allCursos.Where(x => x.Grau == grau).ToList();

                    if (cursos.Count == 2)
                    {
                        cursos.Add(allCursos.FirstOrDefault(x => x.Grau != grau));
                    }
                }
            }

            return cursos;
        }
    }
}
