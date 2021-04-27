angular
    .module('logosApp')
    .controller('BlogController', ['$scope', '$http', '$sce', '$timeout', BlogController]);

function BlogController($scope, $http, $sce, $timeout) {

    var self = this;

    self.postSearch = '';
    self.categoriaFilter = '';

    self.postagens = null;
    self.postagem = null;
    self.texto = [];

    self.categorias = null;

    self.init = function () {

        if (window.location.pathname.includes('Post')) {

            let pathname = window.location.pathname.split('/');

            let postId = parseInt(pathname[pathname.length - 1]);

            self.getPost(postId);

        } else {

            self.getBlog();
        }

    }

    self.getBlog = function () {

        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetBlogContent'
        }).then(function success(response) {

            if (response != null) {

                self.postagens = response.data.postagens;
                self.categorias = response.data.categorias;
            }
        });
    }

    self.handleDates = function (post) {

        let newdate = '';

        if (post != null) {

            let dateStr = post.data.split('T')[0];

            let date = dateStr.split('-');

            newdate = date[2] + '/' + date[1] + '/' + date[0];
        }

        return newdate;

    }

    self.goToBlogContentPage = function (id) {
        window.location = window.location.protocol + '//' + window.location.host + '/Blog/Post/' + id;
    }

    self.getPost = function (postId) {

        $http({
            method: 'POST',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetPostById?postId=' + postId
        }).then(function success(response) {

            if (response != null) {

                self.postagem = response.data;
                self.handlePostContent();
            }
        });
    }

    self.handlePostContent = function () {

        if (self.postagem != null && self.postagem.conteudo) {

            let textoCorrido = self.postagem.conteudo.split('|');

            angular.forEach(textoCorrido, function(paragrafo, index) {

                if (paragrafo != null && paragrafo.length > 0) {

                    if (paragrafo.includes('{NEGRITO}')) {

                        paragrafo = paragrafo.replaceAll('{NEGRITO}', '<b>')
                        paragrafo = paragrafo.replaceAll('{NEGRITO/}', '</b>')
                    }

                    if (paragrafo.includes('{ITALICO}')) {

                        paragrafo = paragrafo.replaceAll('{ITALICO}', '<i>')
                        paragrafo = paragrafo.replaceAll('{ITALICO/}', '</i>')
                    }

                    if (paragrafo.includes('{LISTAPONTO}')) {

                        paragrafo = paragrafo.replaceAll('{LISTAPONTO}', '<li>').replaceAll('{LISTAPONTO/}', '</li>');
                    }

                    if (paragrafo.includes('{LISTAINICIO}'))
                        paragrafo = paragrafo.replaceAll('{LISTAINICIO}', '<ul>')


                    if (paragrafo.includes('{LISTAFIM}'))
                        paragrafo = paragrafo.replaceAll('{LISTAFIM}', '</ul>')

                    if (paragrafo.toUpperCase().includes('BIBLIOGRAFIA') || paragrafo.toUpperCase().includes('REFERÊNCIAS BIBLIOGRÁFICAS')) {
                        paragrafo = '<hr />' + paragrafo;
                    }

                    self.texto.push($sce.trustAsHtml(paragrafo.trim())); 
                }
            });

            $timeout(function () {

                $('.blog-text-paragraphs p').each(function () {

                    if ($(this).text().includes('{CITACAO}')) {

                        $(this).addClass('blog-paragraph-citacao');
                        $(this).text($(this).text().replace('{CITACAO}', ''));
                        $(this).text($(this).text().replace('{CITACAO/}', ''));
                    }
                });

            }, 1000);
        }
    }

    self.filterByCategoria = function (categoria) {

        if (self.categoriaFilter === '')
            self.categoriaFilter = categoria.nome;
        else
            if (self.categoriaFilter == categoria.nome)
                self.categoriaFilter = '';
    }
}

const ETagTextType = {
    NEGRITO: 1
}
