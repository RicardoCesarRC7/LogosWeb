using LogosWeb.Models.Repository.XMLWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LogosWeb.Models.Repository.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IXMLWorker _xmlWorker;

        public BlogRepository(IXMLWorker xmlWorker)
        {
            _xmlWorker = xmlWorker;
        }

        public Models.Blog GetBlogContent()
        {
            Models.Blog blog = new Models.Blog();

            var blogContent = _xmlWorker.Read("Blog");

            var postagensXml = blogContent.GetElementsByTagName("Postagens").Item(0);

            if (postagensXml != null && postagensXml.ChildNodes.Count > 0)
            {
                blog.Postagens = new List<Postagem>();

                foreach (XmlNode postNodeXml in postagensXml.ChildNodes)
                {
                    if (postNodeXml.Name == "Postagem" && postNodeXml.ChildNodes.Count > 0)
                    {
                        Postagem postagem = new Postagem();

                        foreach (XmlNode postNode in postNodeXml.ChildNodes)
                        {
                            switch (postNode.Name)
                            {
                                case "PostagemID":
                                    postagem.PostagemID = int.Parse(postNode.InnerText);
                                    break;

                                case "Titulo":
                                    postagem.Titulo = postNode.InnerText;
                                    break;

                                case "Subtitulo":
                                    postagem.Subtitulo = postNode.InnerText;
                                    break;

                                case "Conteudo":
                                    postagem.Conteudo = postNode.InnerText;
                                    break;

                                case "Categoria":
                                    postagem.Categoria = postNode.InnerText;
                                    break;

                                case "Autor":
                                    postagem.Autor = postNode.InnerText;
                                    break;

                                case "Data":
                                    var dataArr = postNode.InnerText.Split('/');
                                    postagem.Data = new DateTime(int.Parse(dataArr[2]), int.Parse(dataArr[1]), int.Parse(dataArr[0]));
                                    break;

                                case "Imagem":
                                    postagem.Imagem = postNode.InnerText;
                                    break;
                            }
                        }

                        blog.Postagens.Add(postagem);
                    }
                }

                blog.Postagens = blog.Postagens.OrderByDescending(x => x.Data).ToList();
            }

            var categoriasXml = blogContent.GetElementsByTagName("Categorias").Item(0);

            if (categoriasXml != null && categoriasXml.ChildNodes.Count > 0)
            {
                blog.Categorias = new List<Categoria>();

                foreach (XmlNode categoriaNodeXml in categoriasXml.ChildNodes)
                {
                    if (categoriaNodeXml.Name == "Categoria" && categoriaNodeXml.ChildNodes.Count > 0)
                    {
                        Categoria categoria = new Categoria();

                        foreach (XmlNode categoriaNode in categoriaNodeXml.ChildNodes)
                        {
                            switch (categoriaNode.Name)
                            {
                                case "CategoriaID":
                                    categoria.CategoriaID = int.Parse(categoriaNode.InnerText);
                                    break;

                                case "Nome":
                                    categoria.Nome = categoriaNode.InnerText;
                                    break;

                                case "Quantidade":
                                    categoria.Quantidade = int.Parse(categoriaNode.InnerText);
                                    break;
                            }
                        }

                        blog.Categorias.Add(categoria);
                    }
                }
            }

            return blog;
        }

        public Postagem GetPostById(int postId)
        {
            Postagem postagem = null;

            if (postId > 0)
            {
                Models.Blog blogContent = GetBlogContent();

                if (blogContent != null && blogContent.Postagens != null && blogContent.Postagens.Count > 0)
                {
                    postagem = blogContent.Postagens.Where(x => x.PostagemID == postId).FirstOrDefault();
                }
            }

            return postagem;
        }
    }
}
