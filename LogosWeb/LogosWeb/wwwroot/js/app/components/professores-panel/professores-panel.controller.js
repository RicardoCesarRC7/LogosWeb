angular
    .module('logosApp')
    .controller('ProfessoresPanelController', ['$scope', '$http', ProfessoresPanelController]);

function ProfessoresPanelController($scope, $http) {

    var self = this;

    self.professores = null;
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

                self.professores = response.data.filter(p => !p.isVisitante);
            }
        });
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
