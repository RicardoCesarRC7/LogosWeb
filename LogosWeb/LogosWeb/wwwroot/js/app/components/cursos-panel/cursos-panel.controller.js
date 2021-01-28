angular
    .module('logosApp')
    .controller('CursosPanelController', ['$scope', '$http', '$timeout', CursosPanelController]);

function CursosPanelController($scope, $http, $timeout) {

    var self = this;

    self.curso = null;
    self.cursos = null;

    self.professores = null;

    self.sugestoesCursos = [];

    self.init = function () {

        self.getCursos();
    }

    self.getCursos = function () {

        if (!window.location.pathname.includes('Detalhes')) {

            $http({
                method: 'GET',
                url: window.location.protocol + '//' + window.location.host + '/Service/GetCursos'
            }).then(function success(response) {

                if (response != null) {

                    self.cursos = response.data;
                }
            });

        } else {

            let pathname = window.location.pathname.split('/');

            let cursoId = parseInt(pathname[pathname.length - 1]);

            $http({
                method: 'POST',
                url: window.location.protocol + '//' + window.location.host + '/Service/GetCursoById?cursoId=' + cursoId
            }).then(function success(response) {

                if (response != null) {

                    self.curso = response.data;
                    self.selectCursoForm();
                    self.getProfessores(self.curso.cursoID);

                    $timeout(function () {
                        self.getSugestoes(self.curso.grau);
                    }, 2000)

                    $timeout(function () {
                        self.refreshSlider();
                    }, 500);
                }
            });
        }

    }

    self.getProfessores = function (cursoId) {

        $http({
            method: 'POST',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetProfessoresByCursoId?cursoId=' + cursoId
        }).then(function success(response) {

            if (response != null) {

                self.professores = response.data;
            }
        });
    }

    self.getSugestoes = function (grau) {

        $http({
            method: 'POST',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetCursosByGrau?grau=' + grau
        }).then(function success(response) {

            if (response != null) {

                self.sugestoesCursos = response.data.filter(x => x.cursoID != self.curso.cursoID);
            }
        });
    }

    self.parseFormato = function (formatos) {

        let formato = '';

        angular.forEach(formatos, function (formatoId, index) {

            let formatoAtual = '';

            switch (parseInt(formatoId)) {

                case 2:
                    formatoAtual = 'Online';
                    break;

                case 3:
                    formatoAtual = 'Híbrido';
                    break;

                default:
                    formatoAtual = 'Presencial'
                    break;
            }

            if (index === 0)
                formato += formatoAtual;
            else
                formato += ', ' + formatoAtual;
        });


        return formato;
    }

    self.showCursoDetails = function (curso) {

        self.curso = curso;

        $('#curso-details').show();

        self.scrollToCursoDetails();
    }

    self.goToCursoDetails = function (cursoId) {
        window.location = window.location.protocol + '//' + window.location.host + '/Cursos/Detalhes/' + cursoId;
    }

    self.scrollToCursoDetails = function () {

        $('html, body').animate({
            scrollTop: $('#curso-details').offset().top - 100
        }, 1000);
    }

    self.refreshSlider = function () {

        $('.image-slider.owl-carousel').trigger('destroy.owl.carousel');

        $('.image-slider').each(function () {
            $(this).owlCarousel($.extend({
                dots: 1,
                nav: 1,
                center: 1,
                items: 1,
                loop: 1,
                autoHeight: 0,
                margin: 0,
                navText: [
                    '<span class="ti-arrow-left"></span>',
                    '<span class="ti-arrow-right"></span>'
                ],
            }, $(this).data('carousel-options')));
        });
    }

    self.goToCursosPage = function () {
        window.location = window.location.protocol + '//' + window.location.host + '/Cursos';
    }

    self.selectCursoForm = function () {

        $('.curso-interesse-form option').each(function () {

            if ($(this).val() === self.curso.nome) {
                $(this).attr('selected', 'selected');
                return false;
            }
        });

        $('#form-interesse .curso-interesse-form').select2({ theme: 'classic', placeholder: 'Clique para selecionar o curso de interesse' });
    }
}
