angular
    .module('logosApp')
    .controller('BlogController', ['$scope', '$http', BlogController]);

function BlogController($scope, $http) {

    var self = this;

    self.postSearch = '';
    self.categoriaFilter = '';

    self.postagens = null;
    self.postagem = null;

    self.categorias = null;

    self.init = function () {

        if (window.location.pathname.includes('Post')) {

            let pathname = window.location.pathname.split('/');

            let postId = parseInt(pathname[pathname.length - 1]);

            self.getPost(postId);
            
        } 

        self.getBlog();
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
            }
        });
    }

    self.filterByCategoria = function (categoria) {

        if (self.categoriaFilter === '')
            self.categoriaFilter = categoria.nome;
        else
            if (self.categoriaFilter == categoria.nome)
                self.categoriaFilter = '';
    }
}
