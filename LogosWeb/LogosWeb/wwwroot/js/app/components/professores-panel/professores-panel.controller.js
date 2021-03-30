angular
    .module('logosApp')
    .controller('ProfessoresPanelController', ['$scope', '$http', ProfessoresPanelController]);

function ProfessoresPanelController($scope, $http) {

    var self = this;

    self.professores = null;
    self.professoresFixos = null;
    self.professor = null;

    self.init = function () {

        self.getProfessores();
    }

    self.getProfessores = function () {

        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetProfessores'
        }).then(function success(response) {

            if (response != null) {

                self.professores = response.data;
                self.professoresVisitantes = response.data.filter(p => p.isVisitante);
                self.professoresFixos = response.data.filter(p => !p.isVisitante);

                self.ordenarProfessores(self.professoresFixos);
                self.ordenarProfessores(self.professoresVisitantes);
                self.ordenarProfessores(self.professores);
            }
        });
    }

    self.ordenarProfessores = function (professores) {

        if (professores != null && professores.length > 0) {

            professores.sort(function (a, b) {
                if (a.nome > b.nome) {
                    return 1;
                }

                if (a.nome < b.nome) {
                    return -1;
                }

                return 0;
            });
        }
        
    }

    self.showProfDetails = function (professor) {

        self.professor = professor;

        $('#professor-details').show();
        self.scrollToProfDetails();
    }

    self.closeProfDetails = function () {

        $('#professor-details').hide();

        self.professor = null;
    }

    self.scrollToProfDetails = function () {

        $('html, body').animate({
            scrollTop: $('#professor-details').offset().top - 100
        }, 1000);
    }

    self.goToProfessoresPage = function () {
        window.location = window.location.protocol + '//' + window.location.host + '/Professores';
    }
}
