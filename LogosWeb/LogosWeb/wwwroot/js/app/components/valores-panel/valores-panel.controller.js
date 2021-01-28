angular
    .module('logosApp')
    .controller('ValoresPanelController', ['$scope', '$http', ValoresPanelController]);

function ValoresPanelController($scope, $http) {

    var self = this;

    self.valores = null;

    self.init = function () {

        self.getLogosValores();
    }

    self.getLogosValores = function () {

        $http({
            method: 'GET',
            url: window.location.protocol + '//' + window.location.host + '/Service/GetValoresInfo'
        }).then(function success(response) {

            if (response != null) {

                self.valores = response.data.valores;
            }
        });
    }
}
